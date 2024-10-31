using Auction.Common.Application.Interfaces.Answers;

namespace Auction.Common.Application.Interfaces.Handlers;

public interface ICommandHandler<TCommand>
    : IHandler<TCommand, IAnswer>
        where TCommand : class;
