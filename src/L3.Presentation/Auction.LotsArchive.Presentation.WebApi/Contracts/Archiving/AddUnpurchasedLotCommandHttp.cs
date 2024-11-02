using Auction.LotsArchive.Application.L1.Models.Archiving;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record AddUnpurchasedLotCommandHttp(
    LotModel Lot);
