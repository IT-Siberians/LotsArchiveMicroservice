using Auction.Common.Application.Answers;

namespace Auction.Common.Application.Handlers.Abstractions;

public interface IQueryHandler<TQuery, TResponse>
    : IHandler<TQuery, IAnswer<TResponse>>
        where TQuery : class;
