using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.LotsArchive.Application.Models.Sellers;

public record SoldLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    PersonInfoModel Buyer,
    DateTime DateTime,
    decimal Price);