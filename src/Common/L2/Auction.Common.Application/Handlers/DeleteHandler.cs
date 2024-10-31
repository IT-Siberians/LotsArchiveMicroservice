using Auction.Common.Application.Interfaces.Answers;
using Auction.Common.Application.Interfaces.Handlers;
using Auction.Common.Application.Interfaces.Models;
using Auction.Common.Application.Interfaces.Repositories.Base;
using Auction.Common.Application.Interfaces.Repositories.Partial;
using Auction.Common.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.Handlers;

public class DeleteHandler<TCommand, TEntity, TEntityRepository>(
    string entityName,
    TEntityRepository repository)
        : ICommandHandler<TCommand>,
        IDisposable
            where TCommand : class, IModel<Guid>
            where TEntity : class, IEntity<Guid>, IDeletableSoftly
            where TEntityRepository : class, IBaseRepository<TEntity, Guid>, IDeletableRepository<TEntity, Guid>
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
        var existingEntity = await _repository.GetByIdAsync(command.Id, cancellationToken: cancellationToken);
        if (existingEntity is null)
        {
            return BadAnswer.EntityNotFound($"Не существует {_entityName} с Id = {command.Id}");
        }

        _repository.Delete(existingEntity);
        await _repository.SaveChangesAsync(cancellationToken);

        return new OkAnswer($"Удалён {_entityName} с Id = {command.Id}");
    }
}
