using Auction.Common.Application.Answers;

namespace Auction.Common.Application.Handlers.Abstractions;

public interface ICommandHandler<TCommand>
    : IHandler<TCommand, IAnswer>
        where TCommand : class;
