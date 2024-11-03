using Auction.Common.Application.L2.Interfaces.Commands;
using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;

public record GetSellerUnpurchasedLotsQuery(
    Guid SellerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
