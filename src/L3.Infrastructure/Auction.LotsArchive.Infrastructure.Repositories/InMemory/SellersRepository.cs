using Auction.Common.Infrastructure.Repositories.InMemory;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchive.Infrastructure.Repositories.InMemory;

public class SellersRepository(IList<Seller> entities)
    : BaseMemoryRepository<Seller, Guid>(entities),
    ISellersRepository;
