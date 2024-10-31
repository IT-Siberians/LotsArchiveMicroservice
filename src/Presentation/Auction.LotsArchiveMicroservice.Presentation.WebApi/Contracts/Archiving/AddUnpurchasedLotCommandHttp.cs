using Auction.LotsArchiveMicroservice.Application.Models.Archiving;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;

public record AddUnpurchasedLotCommandHttp(
    LotModel Lot);
