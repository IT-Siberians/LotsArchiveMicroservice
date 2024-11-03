using Auction.LotsArchive.Application.L1.Models.Archiving;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;

public record AddRepurchasedLotCommand(
    LotModel Lot,
    PurchasingInfoModel PurchasingInfo);
