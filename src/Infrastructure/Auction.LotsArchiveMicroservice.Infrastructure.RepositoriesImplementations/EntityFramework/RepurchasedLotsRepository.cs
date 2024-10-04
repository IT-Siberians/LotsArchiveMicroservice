using Auction.Common.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;

public class RepurchasedLotsRepository(ApplicationDbContext dbContext)
    : BaseEfRepository<ApplicationDbContext, RepurchasedLot, Guid>(dbContext),
    IRepurchasedLotsRepository;
