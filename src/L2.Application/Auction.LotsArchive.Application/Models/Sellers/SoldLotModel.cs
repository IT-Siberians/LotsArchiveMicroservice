using Auction.Common.Application.Models;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Sellers;

public record SoldLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    PersonInfoModel Buyer,
    DateTime DateTime,
    decimal Price);