using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

public class WithdrawnLot : IEntity<Guid>
{
    public Guid Id { get; }
    public DateTime Date { get; }
    public Lot Lot { get; }

    public WithdrawnLot(Guid id, DateTime date, Lot lot)
    {
        Lot = lot ?? throw new ArgumentNullValueException(nameof(lot));

        Id = id;
        Date = date;
    }
}
