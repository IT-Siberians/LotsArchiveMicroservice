using Auction.Common.Application.L1.Models;

namespace Auction.LotsArchive.Application.L1.Models.Sellers;

public record UnpurchasedLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
