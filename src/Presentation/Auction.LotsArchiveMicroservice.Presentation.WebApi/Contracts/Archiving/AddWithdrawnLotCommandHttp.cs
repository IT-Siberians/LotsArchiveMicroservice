using Auction.LotsArchive.Application.Models.Archiving;
using System;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;

public record AddWithdrawnLotCommandHttp(
    LotModel Lot,
    DateTime DateTime);
