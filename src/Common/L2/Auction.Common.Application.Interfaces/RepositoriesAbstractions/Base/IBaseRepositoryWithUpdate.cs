using Auction.Common.Application.RepositoriesAbstractions.Partial;
using Auction.Common.Domain.Entities;
using System;

namespace Auction.Common.Application.RepositoriesAbstractions.Base;

public interface IBaseRepositoryWithUpdate<TEntity, TKey>
    : IBaseRepository<TEntity, TKey>,
    IUpdatableRepository<TEntity>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
