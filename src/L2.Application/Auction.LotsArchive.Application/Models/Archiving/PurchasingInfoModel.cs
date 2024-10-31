using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Archiving;

public record PurchasingInfoModel(
    DateTime DateTime,
    Guid BuyerId,
    decimal HammerPrice);