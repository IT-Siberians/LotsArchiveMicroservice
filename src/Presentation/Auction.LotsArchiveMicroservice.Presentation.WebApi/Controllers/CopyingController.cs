using Auction.Common.Application.Answers;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchiveMicroservice.Application.Commands.Copying;
using Auction.LotsArchiveMicroservice.Application.Models.Copying;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Controllers;

[Route("/api/v1/[controller]/[action]")]
[ApiController]
public class CopyingController : ControllerBase
{
    [HttpGet("{sellerId:guid}/{lotId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer<LotCopyModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public async Task<ActionResult<IAnswer<LotCopyModel>>> GetLotCopy(
        [FromRoute] Guid sellerId,
        [FromRoute] Guid lotId,
        [FromServices] IQueryHandler<GetLotCopyQuery, LotCopyModel> handler,
        [FromServices] IValidator<GetLotCopyQuery> validator,
        CancellationToken cancellationToken)
    {
        var query = new GetLotCopyQuery(sellerId, lotId);

        var validationResult = validator.Validate(query);
        if (!validationResult.IsValid)
        {
            return this.GetBadRequest<LotCopyModel>(validationResult);
        }

        var answer = await handler.HandleAsync(query, cancellationToken);

        return this.GetActionResult(answer);
    }
}
