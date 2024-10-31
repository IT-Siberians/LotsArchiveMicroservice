using Auction.Common.Application.Answers;
using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.Common.Application.Pages;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchiveMicroservice.Application.Commands.Buyers;
using Auction.LotsArchiveMicroservice.Application.Models.Buyers;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Controllers;

[Route("/api/v1/[controller]/[action]")]
[ApiController]
public class BuyerController : ControllerBase
{
    [HttpGet("{buyerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer<IPageOf<BoughtLotModel>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer<IPageOf<BoughtLotModel>>>> GetBoughtLots(
        Guid buyerId,
        [FromQuery] int? pageItemsCount,
        [FromQuery] int? pageNumber,
        [FromQuery] string? with,
        [FromQuery] string? without,
        [FromServices] ICommandHandler<IsPersonCommand> isHandler,
        [FromServices] IQueryPageHandler<GetBuyerBoughtLotsQuery, BoughtLotModel> getHandler,
        [FromServices] IValidator<GetBuyerBoughtLotsQuery> validator,
        [FromServices] IMapper mapper,
        CancellationToken cancellationToken)
    {
        var query = ControllersHelper.GetPageByIdQuery(
                        buyerId,
                        pageItemsCount,
                        pageNumber,
                        with,
                        without);

        return this.GetPageByIdAsync(
                        query,
                        isHandler,
                        getHandler,
                        validator,
                        mapper,
                        cancellationToken);
    }
}
