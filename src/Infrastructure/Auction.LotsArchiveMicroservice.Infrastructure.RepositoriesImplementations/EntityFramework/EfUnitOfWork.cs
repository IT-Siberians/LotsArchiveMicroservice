using Auction.Common.Domain.RepositoriesAbstractions.Base;
using Auction.Common.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;

public class EfUnitOfWork : IArchiveUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

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
    /// Конструктор UnitOfWork для EntityFramework
    /// </summary>
    /// <param name="dbContext">Значение DB-контекста</param>
    /// <exception cref="ArgumentNullException">Для null-значения</exception>
    protected EfUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        Buyers = new BaseEfRepositoryWithUpdateAndDelete<ApplicationDbContext, Buyer, Guid>(_dbContext);
        Sellers = new BaseEfRepositoryWithUpdateAndDelete<ApplicationDbContext, Seller, Guid>(_dbContext);
        Lots = new BaseEfRepository<ApplicationDbContext, Lot, Guid>(_dbContext);
        RepurchasedLots = new BaseEfRepository<ApplicationDbContext, RepurchasedLot, Guid>(_dbContext);
        WithdrawnLots = new BaseEfRepository<ApplicationDbContext, WithdrawnLot, Guid>(_dbContext);
    }

    /// <summary>
    /// Сохраняет изменения
    /// </summary>
    public void SaveChanges() => _dbContext.SaveChanges();

    /// <summary>
    /// Сохраняет изменения асинхронно
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => _dbContext.SaveChangesAsync(cancellationToken);
}

