namespace Auction.Common.Application.Commands;

public interface IFilteredQuery
{
    FilterQuery? Filter { get; }
}
