using Auction.Common.Infrastructure.RepositoriesImplementations.InMemory;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.InMemory;

public class RepurchasedLotsRepository(IList<RepurchasedLot> entities)
    : BaseMemoryRepository<RepurchasedLot, Guid>(entities),
    IRepurchasedLotsRepository;
