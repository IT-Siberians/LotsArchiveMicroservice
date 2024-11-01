using Auction.Common.Application.Interfaces.Models;
using Auction.LotsArchive.Application.Interfaces.Models.Sellers;

namespace Auction.LotsArchive.Application.Interfaces.Models.Copying;

public record LotCopyModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
