using System.Collections.Generic;

namespace Auction.Common.Application.Pages;

public interface IPageOf<TItem>
{
    int ItemsCount { get; }
    int PageItemsCount { get; }
    int PagesCount { get; }
    int PageNumber { get; }
    IList<TItem> Items { get; }
}
