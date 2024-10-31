using Auction.Common.Application.Models;
using System;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;

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
