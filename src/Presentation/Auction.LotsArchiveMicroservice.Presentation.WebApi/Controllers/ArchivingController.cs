using Auction.Common.Application.Interfaces.Answers;
using Auction.Common.Application.Interfaces.Handlers;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchive.Application.Commands.Archiving;
using Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;
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
public class ArchivingController(
    IMapper mapper)
        : ControllerBase
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OkAnswer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer>> AddRepurchasedLot(
        [FromBody] AddRepurchasedLotCommandHttp command,
        [FromServices] ICommandHandler<AddRepurchasedLotCommand> handler,
        [FromServices] IValidator<AddRepurchasedLotCommand> validator,
        CancellationToken cancellationToken)
    {
        return this.GetCommandActionResultAsync(
                    command,
                    handler,
                    validator,
                    _mapper,
                    isCreated: true,
                    cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OkAnswer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer>> AddUnpurchasedLot(
        [FromBody] AddUnpurchasedLotCommandHttp command,
        [FromServices] ICommandHandler<AddUnpurchasedLotCommand> handler,
        [FromServices] IValidator<AddUnpurchasedLotCommand> validator,
        CancellationToken cancellationToken)
    {
        return this.GetCommandActionResultAsync(
                    command,
                    handler,
                    validator,
                    _mapper,
                    isCreated: true,
                    cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OkAnswer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadValues))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadAnswer))]
    public Task<ActionResult<IAnswer>> AddWithdrawnLot(
        [FromBody] AddWithdrawnLotCommandHttp command,
        [FromServices] ICommandHandler<AddWithdrawnLotCommand> handler,
        [FromServices] IValidator<AddWithdrawnLotCommand> validator,
        CancellationToken cancellationToken)
    {
        return this.GetCommandActionResultAsync(
                    command,
                    handler,
                    validator,
                    _mapper,
                    isCreated: true,
                    cancellationToken);
    }
}
