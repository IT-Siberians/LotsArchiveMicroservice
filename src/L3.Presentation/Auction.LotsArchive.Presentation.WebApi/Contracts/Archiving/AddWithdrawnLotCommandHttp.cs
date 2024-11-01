using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record AddWithdrawnLotCommandHttp(
    LotModel Lot,
    DateTime DateTime);
