using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.Common.Application.Interfaces.Commands;

public record GetItemsPageByIdQuery(
    Guid Id,
    PageQuery? Page,
    FilterQuery? Filter)
        : IModel<Guid>, IPagedQuery, IFilteredQuery;
