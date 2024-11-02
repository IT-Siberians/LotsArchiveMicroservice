using Auction.Common.Application.L1.Models;
using System;

namespace Auction.LotsArchive.Application.L1.Models.Buyers;

public record BoughtLotModel(
    LotInfoModel Lot,
    PersonInfoModel Seller,
    DateTime DateTime,
    decimal HammerPrice);
