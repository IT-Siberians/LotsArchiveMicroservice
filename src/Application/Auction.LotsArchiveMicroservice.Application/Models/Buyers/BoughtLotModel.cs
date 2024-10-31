using Auction.Common.Application.Models;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Buyers;

public record BoughtLotModel(
    LotInfoModel Lot,
    PersonInfoModel Seller,
    DateTime DateTime,
    decimal HammerPrice);
