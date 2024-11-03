using Auction.Common.Application.L2.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Buyers;

public record GetBuyerBoughtLotsQuery(
    Guid BuyerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
