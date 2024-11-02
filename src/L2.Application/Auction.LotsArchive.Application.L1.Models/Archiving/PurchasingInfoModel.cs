using System;

namespace Auction.LotsArchive.Application.L1.Models.Archiving;

public record PurchasingInfoModel(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);