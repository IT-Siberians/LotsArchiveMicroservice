using Auction.Common.Application.Models;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Sellers;

public record WithdrawnLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams,
    DateTime DateTime);
