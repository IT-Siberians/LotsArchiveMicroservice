using Auction.Common.Application.Answers;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.Common.Application.Models;
using Auction.Common.Application.RepositoriesAbstractions.Base;
using Auction.Common.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.Handlers.Implementations;

public class GetByIdHandler<TQuery, TEntity, TModel, TEntityRepository>(
    string entityName,
    TEntityRepository repository,
    Func<TEntity, TModel> toModel,
    string? includeProperties,
    bool useTracking)
        : IQueryHandler<TQuery, TModel>,
        IDisposable
            where TQuery : class, IModel<Guid>
            where TModel : class
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

    public async Task<IAnswer<TModel>> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(
                                    query.Id,
                                    includeProperties,
                                    useTracking,
                                    cancellationToken);

        if (entity is null)
        {
            return BadAnswer<TModel>.EntityNotFound($"Не существует {_entityName} с Id = {query.Id}");
        }

        var model = toModel(entity);

        return new OkAnswer<TModel>(model);
    }
}
