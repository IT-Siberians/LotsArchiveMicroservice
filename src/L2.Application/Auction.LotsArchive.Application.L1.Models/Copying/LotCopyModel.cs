using Auction.Common.Application.L1.Models;
using Auction.LotsArchive.Application.L1.Models.Sellers;

namespace Auction.LotsArchive.Application.L1.Models.Copying;

public record LotCopyModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
