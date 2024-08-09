using Auction.Common.Domain.Entities;
using Auction.Common.Domain.Exceptions;
using Auction.Common.Domain.ValueObjects;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.Entities;

public class Lot : AbstractLot<Guid>
{
    public Seller Seller { get; }
    public Money StartingPrice { get; }
    public Money PriceStep { get; }
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; protected set; }

    public Lot(
        Guid id,
        Name title,
        Text description,
        Seller seller,
        Money startingPrice,
        Money priceStep,
        DateTime startDate,
        DateTime? endDate = null)
        : base(id, title, description)
    {
        Seller = seller ?? throw new ArgumentNullValueException(nameof(seller));
        StartingPrice = startingPrice ?? throw new ArgumentNullValueException(nameof(startingPrice));
        PriceStep = priceStep ?? throw new ArgumentNullValueException(nameof(priceStep));

        StartDate = startDate;
        EndDate = endDate;
    }
}
