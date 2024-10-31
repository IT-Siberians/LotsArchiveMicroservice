using Auction.Common.Application.Commands;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Commands.Sellers;

public record GetSellerUnpurchasedLotsQuery(
    Guid SellerId,
    PageQuery? Page,
    FilterQuery? Filter)
        : IPagedQuery, IFilteredQuery;
