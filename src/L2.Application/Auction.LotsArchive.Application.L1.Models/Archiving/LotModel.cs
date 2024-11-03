using Auction.Common.Application.L1.Models;
using System;

namespace Auction.LotsArchive.Application.L1.Models.Archiving;

public record LotModel(
    Guid Id,
    Guid SellerId,
    string Title,
    string Description,
    decimal StartingPrice,
    decimal BidIncrement,
    decimal? RepurchasePrice,
    DateTime StartDateTime,
    DateTime EndDateTime)
        : IModel<Guid>;
