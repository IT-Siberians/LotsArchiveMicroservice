using Auction.LotsArchive.Application.Interfaces.Models.Archiving;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record AddUnpurchasedLotCommandHttp(
    LotModel Lot);
