using Auction.Common.Domain.Entities;
using Auction.Common.Infrastructure.RepositoriesImplementations.Ef;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.Ef;

public class EfRepository<TEntity>(ApplicationDbContext dbContext)
    : AbstractEfRepository<ApplicationDbContext, TEntity, Guid>(dbContext)
    where TEntity : class, IEntity<Guid>;
