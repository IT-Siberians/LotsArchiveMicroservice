using Auction.Common.Application.Interfaces.Pages;

namespace Auction.Common.Application.Interfaces.Handlers;

public interface IQueryPageHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, IPageOf<TResponse>>
        where TQuery : class;
