using Auction.Common.Application.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.Commands.Buyers;

public record GetBuyerBoughtLotsQuery(
    Guid BuyerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
