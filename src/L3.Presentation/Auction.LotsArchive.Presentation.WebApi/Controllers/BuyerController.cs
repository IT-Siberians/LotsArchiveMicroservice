using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L2.Interfaces.Pages;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchive.Application.L1.Models.Buyers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Buyers;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchive.Presentation.WebApi.Controllers;

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
