using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.LotsArchive.Application.Models.Buyers;

public record BoughtLotModel(
    LotInfoModel Lot,
    PersonInfoModel Seller,
    DateTime DateTime,
    decimal HammerPrice);
