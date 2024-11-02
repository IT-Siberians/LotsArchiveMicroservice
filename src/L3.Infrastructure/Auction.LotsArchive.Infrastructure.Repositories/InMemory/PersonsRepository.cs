using Auction.Common.Infrastructure.Repositories.InMemory;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Auction.LotsArchive.Infrastructure.Repositories.InMemory;

public class PersonsRepository(IList<Person> entities)
    : BaseMemoryRepositoryWithDelete<Person, Guid>(entities),
    IPersonsRepository;
