using Auction.LotsArchive.Application.Interfaces.Models.Archiving;

namespace Auction.LotsArchive.Application.Interfaces.Commands.Archiving;

public record AddUnpurchasedLotCommand(
    LotModel Lot);
