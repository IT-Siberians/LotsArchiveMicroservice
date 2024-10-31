using Auction.Common.Application.Interfaces.Models;
using Auction.LotsArchive.Application.Models.Sellers;

namespace Auction.LotsArchive.Application.Models.Copying;

public record LotCopyModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
