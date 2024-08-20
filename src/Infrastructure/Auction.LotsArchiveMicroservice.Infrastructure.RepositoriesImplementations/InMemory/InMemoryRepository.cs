﻿using Auction.Common.Domain.Entities;
using Auction.Common.Infrastructure.RepositoriesImplementations.InMemory;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.InMemory;

public class InMemoryRepository<TEntity>(IEnumerable<TEntity> entities)
    : AbstractInMemoryRepository<TEntity, Guid>(entities)
    where TEntity : class, IEntity<Guid>;
