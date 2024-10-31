namespace Auction.Common.Application.Answers;

public interface IBadBaseAnswer : IAnswer;

public interface IBadBaseAnswer<TResult> : IBadBaseAnswer, IAnswer<TResult>;
