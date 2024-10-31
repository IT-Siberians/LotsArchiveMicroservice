using Auction.Common.Application.Interfaces.Answers;
using Auction.Common.Application.Interfaces.Handlers;
using Auction.Common.Application.Interfaces.Models;
using Auction.Common.Application.Interfaces.Repositories.Base;
using Auction.Common.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.Handlers;

public class IsHandler<TCommand, TEntity, TEntityRepository>(
    string entityName,
    TEntityRepository repository)
        : ICommandHandler<TCommand>,
        IDisposable
            where TCommand : class, IModel<Guid>
            where TEntity : class, IEntity<Guid>
            where TEntityRepository : class, IBaseRepository<TEntity, Guid>
{
    private readonly TEntityRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly string _entityName = entityName ?? throw new ArgumentNullException(nameof(entityName));

    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _repository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(
                                    command.Id,
                                    useTracking: false,
                                    cancellationToken: cancellationToken);

        if (entity is null)
        {
            return BadAnswer.EntityNotFound($"Не существует {_entityName} с Id = {command.Id}");
        }

        return new OkAnswer($"Существует {_entityName} с Id = {command.Id}");
    }
}
