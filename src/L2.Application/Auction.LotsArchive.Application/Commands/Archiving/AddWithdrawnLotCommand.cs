using Auction.LotsArchive.Application.Models.Archiving;
using System;

namespace Auction.LotsArchive.Application.Commands.Archiving;

public record AddWithdrawnLotCommand(
    LotModel Lot,
    DateTime DateTime);
