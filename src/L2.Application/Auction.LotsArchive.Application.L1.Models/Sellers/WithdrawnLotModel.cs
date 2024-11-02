using Auction.Common.Application.L1.Models;
using System;

namespace Auction.LotsArchive.Application.L1.Models.Sellers;

public record WithdrawnLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    DateTime DateTime);
