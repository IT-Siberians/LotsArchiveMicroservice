using System;

namespace Auction.LotsArchive.Application.Models.Archiving;

public record PurchasingInfoModel(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);