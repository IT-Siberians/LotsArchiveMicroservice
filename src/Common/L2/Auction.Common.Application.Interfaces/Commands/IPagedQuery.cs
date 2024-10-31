namespace Auction.Common.Application.Interfaces.Commands;

public interface IPagedQuery
{
    PageQuery? Page { get; }
}
