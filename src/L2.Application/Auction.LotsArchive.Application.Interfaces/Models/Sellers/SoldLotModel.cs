using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.LotsArchive.Application.Interfaces.Models.Sellers;

public record SoldLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    PersonInfoModel Buyer,
    DateTime DateTime,
    decimal Price);