using System;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;

public record PurchasingInfoModelHttp(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);
