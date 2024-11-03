using System;

namespace Auction.LotsArchive.Application.L1.Models.Sellers;

public record LotParamsModel(
    decimal StartingPrice,
    decimal BidIncrement,
    decimal? RepurchasePrice,
    DateTime StartDateTime,
    DateTime EndDateTime);
