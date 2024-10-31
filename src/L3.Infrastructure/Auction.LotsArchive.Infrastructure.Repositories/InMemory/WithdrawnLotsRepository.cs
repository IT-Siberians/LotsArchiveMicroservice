using Auction.Common.Infrastructure.Repositories.InMemory;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchive.Infrastructure.Repositories.InMemory;

public class WithdrawnLotsRepository(IList<WithdrawnLot> entities)
    : BaseMemoryRepository<WithdrawnLot, Guid>(entities),
    IWithdrawnLotsRepository;
