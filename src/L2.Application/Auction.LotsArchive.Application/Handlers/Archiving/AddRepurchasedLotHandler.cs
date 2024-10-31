﻿using Auction.Common.Application.Interfaces.Answers;
using Auction.Common.Application.Interfaces.Handlers;
using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchive.Application.Commands.Archiving;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchive.Application.Handlers.Archiving;

public class AddRepurchasedLotHandler(
    ILotsRepository lotsRepository,
    IRepurchasedLotsRepository repurchasedLotsRepository,
    ISellersRepository sellersRepository,
    IBuyersRepository buyersRepository)
        : ICommandHandler<AddRepurchasedLotCommand>,
        IDisposable
{
    private readonly ILotsRepository _lotsRepository = lotsRepository ?? throw new ArgumentNullException(nameof(lotsRepository));
    private readonly IRepurchasedLotsRepository _repurchasedLotsRepository = repurchasedLotsRepository ?? throw new ArgumentNullException(nameof(repurchasedLotsRepository));
    private readonly ISellersRepository _sellersRepository = sellersRepository ?? throw new ArgumentNullException(nameof(sellersRepository));
    private readonly IBuyersRepository _buyersRepository = buyersRepository ?? throw new ArgumentNullException(nameof(buyersRepository));

    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _lotsRepository.Dispose();
            _repurchasedLotsRepository.Dispose();
            _sellersRepository.Dispose();
            _buyersRepository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer> HandleAsync(AddRepurchasedLotCommand command, CancellationToken cancellationToken = default)
    {
        var existingLot = await _lotsRepository.GetByIdAsync(command.Lot.Id, cancellationToken: cancellationToken);
        if (existingLot is not null)
        {
            return BadAnswer.Error($"Уже существует лот с Id = {command.Lot.Id}");
        }

        var seller = await _sellersRepository.GetByIdAsync(command.Lot.SellerId, cancellationToken: cancellationToken);
        if (seller is null)
        {
            return BadAnswer.EntityNotFound($"Не существует продавец с Id = {command.Lot.SellerId}");
        }

        var buyer = await _buyersRepository.GetByIdAsync(command.PurchasingInfo.BuyerId, cancellationToken: cancellationToken);
        if (buyer is null)
        {
            return BadAnswer.EntityNotFound($"Не существует покупатель с Id = {command.PurchasingInfo.BuyerId}");
        }

        var title = new Title(command.Lot.Title);
        var description = new Text(command.Lot.Description);
        var startingPrice = new Price(command.Lot.StartingPrice);
        var bidIncrement = new Price(command.Lot.BidIncrement);
        var repurchasePrice = command.Lot.RepurchasePrice is null ? null : new Price(command.Lot.RepurchasePrice!.Value);
        var hammerPrice = new Price(command.PurchasingInfo.HammerPrice);

        var lot = new Lot(
            command.Lot.Id,
            title,
            description,
            seller,
            startingPrice,
            bidIncrement,
            repurchasePrice,
            command.Lot.StartDateTime,
            command.Lot.EndDateTime);

        var repurchasedLot = new RepurchasedLot(
            Guid.NewGuid(),
            command.PurchasingInfo.DateTime,
            lot,
            buyer,
            hammerPrice);

        lot.SetRepurchasedLot(repurchasedLot);

        await _lotsRepository.AddAsync(lot, cancellationToken);
        await _repurchasedLotsRepository.AddAsync(repurchasedLot, cancellationToken);
        await _lotsRepository.SaveChangesAsync(cancellationToken);

        return new OkAnswer($"Лот с Id = {command.Lot.Id} создан");
    }
}
