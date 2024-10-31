namespace Auction.Common.Application.Interfaces.Answers;

public interface IBadBaseAnswer : IAnswer;

public interface IBadBaseAnswer<TResult> : IBadBaseAnswer, IAnswer<TResult>;
