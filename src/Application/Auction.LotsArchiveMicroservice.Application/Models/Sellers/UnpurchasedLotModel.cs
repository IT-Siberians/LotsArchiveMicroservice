using Auction.Common.Application.Models;

namespace Auction.LotsArchiveMicroservice.Application.Models.Sellers;

public record UnpurchasedLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
