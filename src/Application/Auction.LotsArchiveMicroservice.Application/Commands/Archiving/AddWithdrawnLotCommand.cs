using Auction.LotsArchiveMicroservice.Application.Models.Archiving;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Commands.Archiving;

public record AddWithdrawnLotCommand(
    LotModel Lot,
    DateTime DateTime);
