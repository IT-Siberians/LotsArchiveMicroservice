using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record PurchasingInfoModelWeb(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);
