using Auction.Common.Infrastructure.Repositories.InMemory;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchive.Infrastructure.Repositories.InMemory;

public class LotsRepository(IList<Lot> entities)
    : BaseMemoryRepository<Lot, Guid>(entities),
    ILotsRepository;
