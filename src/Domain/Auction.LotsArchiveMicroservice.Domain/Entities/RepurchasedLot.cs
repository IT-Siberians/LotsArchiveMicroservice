using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

public class RepurchasedLot : IEntity<Guid>
{
    public Guid Id { get; }
    public DateTime Date { get; }

    public Lot Lot { get; }
    public Buyer Buyer { get; }
    public Money EndPrice { get; }

    public RepurchasedLot(
        Guid id,
        DateTime date,
        Lot lot,
        Buyer buyer,
        Money endPrice)
    {
        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));
        Buyer = buyer ?? throw new ArgumentNullValueException(nameof(buyer));
        EndPrice = endPrice ?? throw new ArgumentNullValueException(nameof(endPrice));

        Id = id;
        Date = date;
    }
}
