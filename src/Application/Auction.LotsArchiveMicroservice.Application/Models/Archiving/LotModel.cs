using Auction.Common.Application.Models;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Models.Archiving;

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
