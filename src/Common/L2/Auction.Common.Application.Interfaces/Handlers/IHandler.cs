using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.Interfaces.Handlers;

public interface IHandler<TInput, TOutput> where TInput : class
{
    Task<TOutput> HandleAsync(TInput input, CancellationToken cancellationToken = default);
}
