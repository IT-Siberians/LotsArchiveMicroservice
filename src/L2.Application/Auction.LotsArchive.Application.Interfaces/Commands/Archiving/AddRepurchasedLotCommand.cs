using Auction.LotsArchive.Application.Interfaces.Models.Archiving;

namespace Auction.LotsArchive.Application.Interfaces.Commands.Archiving;

public record AddRepurchasedLotCommand(
    LotModel Lot,
    PurchasingInfoModel PurchasingInfo);
