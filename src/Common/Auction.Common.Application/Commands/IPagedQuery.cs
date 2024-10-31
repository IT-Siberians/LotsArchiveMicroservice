namespace Auction.Common.Application.Commands;

public interface IPagedQuery
{
    PageQuery? Page { get; }
}
