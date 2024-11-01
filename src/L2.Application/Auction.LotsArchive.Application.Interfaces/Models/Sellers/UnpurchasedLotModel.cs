using Auction.Common.Application.Interfaces.Models;

namespace Auction.LotsArchive.Application.Interfaces.Models.Sellers;

public record UnpurchasedLotModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
