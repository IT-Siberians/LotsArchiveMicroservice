using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Sellers;

public record LotParamsModel(
    decimal StartingPrice,
    decimal BidIncrement,
    decimal? RepurchasePrice,
    DateTime StartDateTime,
    DateTime EndDateTime);
