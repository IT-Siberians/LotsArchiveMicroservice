using Auction.Common.Application.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.Commands.Sellers;

public record GetSellerWithdrawnLotsQuery(
    Guid SellerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
