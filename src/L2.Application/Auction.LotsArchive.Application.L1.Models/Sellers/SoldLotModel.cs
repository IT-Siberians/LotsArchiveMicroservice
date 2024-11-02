using Auction.Common.Application.L1.Models;
using System;

namespace Auction.LotsArchive.Application.L1.Models.Sellers;

public record SoldLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    PersonInfoModel Buyer,
    DateTime DateTime,
    decimal Price);