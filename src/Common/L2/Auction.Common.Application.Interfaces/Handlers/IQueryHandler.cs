using Auction.Common.Application.Interfaces.Answers;

namespace Auction.Common.Application.Interfaces.Handlers;

public interface IQueryHandler<TQuery, TResponse>
    : IHandler<TQuery, IAnswer<TResponse>>
        where TQuery : class;
