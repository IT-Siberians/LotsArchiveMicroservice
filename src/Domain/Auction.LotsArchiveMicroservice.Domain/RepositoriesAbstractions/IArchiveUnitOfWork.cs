using Auction.Common.Domain.RepositoriesAbstractions;
using Auction.Common.Domain.RepositoriesAbstractions.Base;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;

public interface IArchiveUnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Покупатели
    /// </summary>
    IBaseRepositoryWithUpdateAndDelete<Buyer, Guid> Buyers { get; }

    /// <summary>
    /// Продавцы
    /// </summary>
    IBaseRepositoryWithUpdateAndDelete<Seller, Guid> Sellers { get; }

    /// <summary>
    /// Лоты (основная информация о лоте)
    /// </summary>
    IBaseRepository<Lot, Guid> Lots { get; }

    /// <summary>
    /// Выкпленные лоты (информация о продаже)
    /// </summary>
    IBaseRepository<RepurchasedLot, Guid> RepurchasedLots { get; }

    /// <summary>
    /// Отменённые лоты (информация об отмене)
    /// </summary>
    IBaseRepository<WithdrawnLot, Guid> WithdrawnLots { get; }
}
