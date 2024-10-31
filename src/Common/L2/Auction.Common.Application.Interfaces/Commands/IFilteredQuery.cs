namespace Auction.Common.Application.Interfaces.Commands;

public interface IFilteredQuery
{
    FilterQuery? Filter { get; }
}
