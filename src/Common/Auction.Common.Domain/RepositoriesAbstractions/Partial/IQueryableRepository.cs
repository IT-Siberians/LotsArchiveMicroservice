﻿using System.Linq;

namespace Auction.Common.Domain.RepositoriesAbstractions.Partial;

/// <summary>
/// Интерфейс репозитория для создаия запроса
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IQueryableRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Возвращает IQueryable для создания запроса к набору сущностей
    /// </summary>
    IQueryable<TEntity> Query();
}
