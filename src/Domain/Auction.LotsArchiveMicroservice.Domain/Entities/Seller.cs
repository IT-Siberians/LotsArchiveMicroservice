using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

public class Seller : AbstractPerson<Guid>
{
    private ICollection<RepurchasedLot>? _soldLots;
    private ICollection<WithdrawnLot>? _withdrawnLots;
    private ICollection<Lot>? _unpurchasedLots;

    public IReadOnlyCollection<RepurchasedLot> SoldLots => _soldLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_soldLots));
    public IReadOnlyCollection<WithdrawnLot> WithdrawnLots => _withdrawnLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_withdrawnLots));
    public IReadOnlyCollection<Lot> UnpurchasedLots => _unpurchasedLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_unpurchasedLots));

    public Seller(
        Guid id,
        Name username,
        ICollection<RepurchasedLot> soldLots,
        ICollection<WithdrawnLot> withdrawnLots,
        ICollection<Lot> unpurchasedLots)
        : base(id, username)
    {
        _soldLots = soldLots ?? throw new ArgumentNullValueException(nameof(soldLots));
        _withdrawnLots = withdrawnLots ?? throw new ArgumentNullValueException(nameof(withdrawnLots));
        _unpurchasedLots = unpurchasedLots ?? throw new ArgumentNullValueException(nameof(unpurchasedLots));
    }

    public void AddWithdrawnLot(WithdrawnLot lot)
    {
        if (lot == null) throw new ArgumentNullValueException(nameof(lot));
        if (_withdrawnLots == null) throw new FieldNullValueException(nameof(_withdrawnLots));

        _withdrawnLots.Add(lot);
    }
}