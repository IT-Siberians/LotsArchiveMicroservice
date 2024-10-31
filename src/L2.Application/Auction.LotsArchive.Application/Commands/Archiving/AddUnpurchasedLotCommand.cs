using Auction.LotsArchiveMicroservice.Application.Models.Archiving;

namespace Auction.LotsArchiveMicroservice.Application.Commands.Archiving;

public record AddUnpurchasedLotCommand(
    LotModel Lot);
