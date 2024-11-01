using System;

namespace Auction.LotsArchive.Application.Interfaces.Models.Archiving;

public record PurchasingInfoModel(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);