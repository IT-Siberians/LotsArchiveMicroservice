using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.LotsArchive.Application.Models.Sellers;

public record WithdrawnLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    DateTime DateTime);
