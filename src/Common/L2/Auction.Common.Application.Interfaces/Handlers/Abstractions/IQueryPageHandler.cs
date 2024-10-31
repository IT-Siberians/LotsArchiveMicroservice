using Auction.Common.Application.Pages;

namespace Auction.Common.Application.Handlers.Abstractions;

public interface IQueryPageHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, IPageOf<TResponse>>
        where TQuery : class;
