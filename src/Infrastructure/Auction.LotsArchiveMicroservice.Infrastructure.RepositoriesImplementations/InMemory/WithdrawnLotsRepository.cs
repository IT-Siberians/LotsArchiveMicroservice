using Auction.Common.Infrastructure.RepositoriesImplementations.InMemory;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.InMemory;

public class WithdrawnLotsRepository(IList<WithdrawnLot> entities)
    : BaseMemoryRepository<WithdrawnLot, Guid>(entities),
    IWithdrawnLotsRepository;
