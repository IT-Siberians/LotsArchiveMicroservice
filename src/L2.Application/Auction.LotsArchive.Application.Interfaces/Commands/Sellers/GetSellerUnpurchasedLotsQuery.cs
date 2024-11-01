using Auction.Common.Application.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.Interfaces.Commands.Sellers;

public record GetSellerUnpurchasedLotsQuery(
    Guid SellerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
