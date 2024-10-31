using Auction.Common.Application.Models;
using Auction.LotsArchiveMicroservice.Application.Models.Sellers;

namespace Auction.LotsArchiveMicroservice.Application.Models.Copying;

public record LotCopyModel(
    LotInfoModel LotInfo,
    LotParamsModel LotParams);
