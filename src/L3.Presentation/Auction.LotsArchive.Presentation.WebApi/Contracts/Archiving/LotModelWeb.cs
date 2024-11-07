using Auction.Common.Application.L1.Models;
using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record LotModelWeb(
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
