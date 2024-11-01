using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record LotModelHttp(
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
