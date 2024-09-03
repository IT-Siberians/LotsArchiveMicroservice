using Auction.Common.Domain.RepositoriesAbstractions.Base;
using Auction.Common.Infrastructure.RepositoriesImplementations.InMemory;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.InMemory;

/// <summary>
/// UnitOfWork для InMemory репозиториев
/// </summary>
public class MemoryUnitOfWork : IArchiveUnitOfWork
{
    /// <summary>
    /// Покупатели
    /// </summary>
    public IBaseRepositoryWithUpdateAndDelete<Buyer, Guid> Buyers { get; }

    /// <summary>
    /// Продавцы
    /// </summary>
    public IBaseRepositoryWithUpdateAndDelete<Seller, Guid> Sellers { get; }

    /// <summary>
    /// Лоты (основная информация о лоте)
    /// </summary>
    public IBaseRepository<Lot, Guid> Lots { get; }

    /// <summary>
    /// Выкпленные лоты (информация о продаже)
    /// </summary>
    public IBaseRepository<RepurchasedLot, Guid> RepurchasedLots { get; }

    /// <summary>
    /// Отменённые лоты (информация об отмене)
    /// </summary>
    public IBaseRepository<WithdrawnLot, Guid> WithdrawnLots { get; }

    /// <summary>
    /// Конструктор UnitOfWork для InMemory репозиториев
    /// </summary>
    protected MemoryUnitOfWork(
        IList<Buyer> buyers,
        IList<Seller> sellers,
        IList<Lot> lots,
        IList<RepurchasedLot> repurchasedLots,
        IList<WithdrawnLot> withdrawnLots)
    {
        ArgumentNullException.ThrowIfNull(buyers, nameof(buyers));
        ArgumentNullException.ThrowIfNull(sellers, nameof(sellers));
        ArgumentNullException.ThrowIfNull(lots, nameof(lots));
        ArgumentNullException.ThrowIfNull(repurchasedLots, nameof(repurchasedLots));
        ArgumentNullException.ThrowIfNull(withdrawnLots, nameof(withdrawnLots));

        Buyers = new BaseMemoryRepositoryWithUpdateAndDelete<Buyer, Guid>(buyers);
        Sellers = new BaseMemoryRepositoryWithUpdateAndDelete<Seller, Guid>(sellers);
        Lots = new BaseMemoryRepository<Lot, Guid>(lots);
        RepurchasedLots = new BaseMemoryRepository<RepurchasedLot, Guid>(repurchasedLots);
        WithdrawnLots = new BaseMemoryRepository<WithdrawnLot, Guid>(withdrawnLots);
    }

    /// <summary>
    /// Сохраняет изменения
    /// </summary>
    public void SaveChanges() { }

    /// <summary>
    /// Сохраняет изменения асинхронно
    /// </summary>
    public Task SaveChangesAsync(CancellationToken _ = default)
        => Task.CompletedTask;
}

