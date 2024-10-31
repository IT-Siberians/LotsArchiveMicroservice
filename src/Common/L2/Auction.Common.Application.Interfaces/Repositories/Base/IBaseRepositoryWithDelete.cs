using Auction.Common.Application.Interfaces.Repositories.Partial;
using Auction.Common.Domain.Entities;
using System;

namespace Auction.Common.Application.Interfaces.Repositories.Base;

public interface IBaseRepositoryWithDelete<TEntity, TKey>
    : IBaseRepository<TEntity, TKey>,
    IDeletableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
