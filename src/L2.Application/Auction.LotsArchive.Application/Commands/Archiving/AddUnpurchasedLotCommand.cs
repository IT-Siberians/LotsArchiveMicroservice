using Auction.LotsArchive.Application.Models.Archiving;

namespace Auction.LotsArchive.Application.Commands.Archiving;

public record AddUnpurchasedLotCommand(
    LotModel Lot);
