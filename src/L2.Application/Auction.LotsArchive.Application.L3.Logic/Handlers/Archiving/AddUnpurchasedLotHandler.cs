using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L3.Logic.Strings;
using Auction.Common.Domain.ValueObjects.Numeric;
using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Archiving;

public class AddUnpurchasedLotHandler(
    ILotsRepository lotsRepository,
    ISellersRepository sellersRepository)
        : ICommandHandler<AddUnpurchasedLotCommand>,
        IDisposable
{
    private readonly ILotsRepository _lotsRepository = lotsRepository ?? throw new ArgumentNullException(nameof(lotsRepository));
    private readonly ISellersRepository _sellersRepository = sellersRepository ?? throw new ArgumentNullException(nameof(sellersRepository));

    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _lotsRepository.Dispose();
            _sellersRepository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer> HandleAsync(AddUnpurchasedLotCommand command, CancellationToken cancellationToken = default)
    {
        var existingLot = await _lotsRepository.GetByIdAsync(command.Lot.Id, cancellationToken: cancellationToken);
        if (existingLot is not null)
        {
            return BadAnswer.Error(CommonMessages.AlreadyExistsWithId, Names.Lot, command.Lot.Id);
        }

        var seller = await _sellersRepository.GetByIdAsync(command.Lot.SellerId, cancellationToken: cancellationToken);
        if (seller is null)
        {
            return BadAnswer.EntityNotFound(CommonMessages.DoesntExistWithId, Names.Seller, command.Lot.SellerId);
        }

        var title = new Title(command.Lot.Title);
        var description = new Text(command.Lot.Description);
        var startingPrice = new Price(command.Lot.StartingPrice);
        var bidIncrement = new Price(command.Lot.BidIncrement);
        var repurchasePrice = command.Lot.RepurchasePrice is null ? null : new Price(command.Lot.RepurchasePrice!.Value);

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

        await _lotsRepository.AddAsync(lot, cancellationToken);
        await _lotsRepository.SaveChangesAsync(cancellationToken);

        return new OkAnswer(CommonMessages.CreatedWithId, Names.Lot, command.Lot.Id);
    }
}
