using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

public class Buyer : AbstractPerson<Guid>
{
    private ICollection<RepurchasedLot>? _boughtLots;

    public IReadOnlyCollection<RepurchasedLot> BoughtLots => _boughtLots
        ?.ToList()
        ?? throw new FieldNullValueException(nameof(_boughtLots));

    public Buyer(
        Guid id,
        Name username,
        ICollection<RepurchasedLot> boughtLots)
        : base(id, username)
    {
        _boughtLots = boughtLots ?? throw new ArgumentNullValueException(nameof(boughtLots));
    }
}
