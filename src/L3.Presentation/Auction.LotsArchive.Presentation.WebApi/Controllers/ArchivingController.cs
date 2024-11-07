﻿using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Presentation.Controllers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;
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
        [FromBody] AddRepurchasedLotCommandWeb command,
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
        [FromBody] AddUnpurchasedLotCommandWeb command,
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
        [FromBody] AddWithdrawnLotCommandWeb command,
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
