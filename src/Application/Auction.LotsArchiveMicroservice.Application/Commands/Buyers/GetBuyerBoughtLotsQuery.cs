using Auction.Common.Application.Commands;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Commands.Buyers;

public record GetBuyerBoughtLotsQuery(
    Guid BuyerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
