﻿using Auction.Common.Application.Answers;
using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.Common.Application.Pages;
using Auction.Common.Application.RepositoriesAbstractions.Base;
using Auction.Common.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.Common.Application.Handlers.Implementations;

public class GetPageHandler<TQuery, TEntity, TModel, TEntityRepository, TOrderKey>(
    TEntityRepository repository,
    Func<TEntity, TModel> toModel,
    Expression<Func<TEntity, TOrderKey>>? orderKeySelector,
    string? includeProperties,
    bool useTracking)
        : IQueryPageHandler<TQuery, TModel>,
        IDisposable
            where TQuery : class, IPagedQuery
            where TModel : class
            where TEntity : class, IEntity<Guid>
            where TEntityRepository : class, IBaseRepository<TEntity, Guid>
{
    private readonly TEntityRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    private bool _isDisposed;

    protected Expression<Func<TEntity, bool>>? Filter;
    protected TQuery? Query;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _repository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer<IPageOf<TModel>>> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
    {
        Query = query ?? throw new ArgumentNullException(nameof(query));

        var entitiesPage = await _repository.GetAsync(
                                    Filter,
                                    orderKeySelector,
                                    page: query.Page,
                                    includeProperties,
                                    useTracking,
                                    cancellationToken);

        var modelsPage = new PageOf<TModel>(
                                entitiesPage.ItemsCount,
                                entitiesPage.PageItemsCount,
                                entitiesPage.PagesCount,
                                entitiesPage.PageNumber,
                                entitiesPage.Items.Select(toModel).ToList());

        return new OkAnswer<IPageOf<TModel>>(modelsPage);
    }
}
