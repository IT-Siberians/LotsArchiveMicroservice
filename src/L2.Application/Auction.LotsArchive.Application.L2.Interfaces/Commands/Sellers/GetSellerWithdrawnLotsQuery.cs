using Auction.Common.Application.L2.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;

public record GetSellerWithdrawnLotsQuery(
    Guid SellerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
