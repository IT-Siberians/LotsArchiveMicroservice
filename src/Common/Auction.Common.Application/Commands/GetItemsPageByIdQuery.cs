using Auction.Common.Application.Models;
using System;

namespace Auction.Common.Application.Commands;

public record GetItemsPageByIdQuery(
    Guid Id,
    PageQuery? Page,
    FilterQuery? Filter)
        : IModel<Guid>, IPagedQuery, IFilteredQuery;
