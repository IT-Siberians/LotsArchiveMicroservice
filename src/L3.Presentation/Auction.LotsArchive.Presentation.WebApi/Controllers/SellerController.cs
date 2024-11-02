using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L2.Interfaces.Pages;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchive.Application.L1.Models.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;
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
public class SellerController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet("{sellerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer<IPageOf<SoldLotModel>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer<IPageOf<SoldLotModel>>>> GetSoldLots(
        [FromRoute] Guid sellerId,
        [FromQuery] int? pageItemsCount,
        [FromQuery] int? pageNumber,
        [FromQuery] string? with,
        [FromQuery] string? without,
        [FromServices] ICommandHandler<IsPersonCommand> isHandler,
        [FromServices] IQueryPageHandler<GetSellerSoldLotsQuery, SoldLotModel> getHandler,
        [FromServices] IValidator<GetSellerSoldLotsQuery> validator,
        CancellationToken cancellationToken)
    {
        var query = ControllersHelper.GetPageByIdQuery(
                        sellerId,
                        pageItemsCount,
                        pageNumber,
                        with,
                        without);

        return this.GetPageByIdAsync(
                        query,
                        isHandler,
                        getHandler,
                        validator,
                        _mapper,
                        cancellationToken);
    }

    [HttpGet("{sellerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer<IPageOf<UnpurchasedLotModel>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer<IPageOf<UnpurchasedLotModel>>>> GetUnpurchasedLots(
        [FromRoute] Guid sellerId,
        [FromQuery] int? pageItemsCount,
        [FromQuery] int? pageNumber,
        [FromQuery] string? with,
        [FromQuery] string? without,
        [FromServices] ICommandHandler<IsPersonCommand> isHandler,
        [FromServices] IQueryPageHandler<GetSellerUnpurchasedLotsQuery, UnpurchasedLotModel> getHandler,
        [FromServices] IValidator<GetSellerUnpurchasedLotsQuery> validator,
        CancellationToken cancellationToken)
    {
        var query = ControllersHelper.GetPageByIdQuery(
                        sellerId,
                        pageItemsCount,
                        pageNumber,
                        with,
                        without);

        return this.GetPageByIdAsync(
                        query,
                        isHandler,
                        getHandler,
                        validator,
                        _mapper,
                        cancellationToken);
    }

    [HttpGet("{sellerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkAnswer<IPageOf<WithdrawnLotModel>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer<IPageOf<WithdrawnLotModel>>>> GetWithdrawnLots(
        [FromRoute] Guid sellerId,
        [FromQuery] int? pageItemsCount,
        [FromQuery] int? pageNumber,
        [FromQuery] string? with,
        [FromQuery] string? without,
        [FromServices] ICommandHandler<IsPersonCommand> isHandler,
        [FromServices] IQueryPageHandler<GetSellerWithdrawnLotsQuery, WithdrawnLotModel> getHandler,
        [FromServices] IValidator<GetSellerWithdrawnLotsQuery> validator,
        CancellationToken cancellationToken)
    {
        var query = ControllersHelper.GetPageByIdQuery(
                        sellerId,
                        pageItemsCount,
                        pageNumber,
                        with,
                        without);

        return this.GetPageByIdAsync(
                        query,
                        isHandler,
                        getHandler,
                        validator,
                        _mapper,
                        cancellationToken);
    }
}
