using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using System;

namespace Auction.LotsArchive.Application.Interfaces.Commands.Archiving;

public record AddWithdrawnLotCommand(
    LotModel Lot,
    DateTime DateTime);
