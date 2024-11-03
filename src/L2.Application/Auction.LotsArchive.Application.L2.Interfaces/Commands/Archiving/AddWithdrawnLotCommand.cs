using Auction.LotsArchive.Application.L1.Models.Archiving;
using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;

public record AddWithdrawnLotCommand(
    LotModel Lot,
    DateTime DateTime);
