namespace Auction.Common.Application.Answers;

public class OkAnswer(string message) : IOkAnswer
{
    public string Message { get; } = message;
}

public class OkAnswer<TResult>(TResult result) : IOkAnswer<TResult>
{
    public TResult Result { get; } = result;
}
