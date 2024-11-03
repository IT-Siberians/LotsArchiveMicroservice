using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record PurchasingInfoModelHttp(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);
