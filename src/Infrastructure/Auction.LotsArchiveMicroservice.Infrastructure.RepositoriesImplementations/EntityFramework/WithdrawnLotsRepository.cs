using Auction.Common.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;

public class WithdrawnLotsRepository(ApplicationDbContext dbContext)
    : BaseEfRepository<ApplicationDbContext, WithdrawnLot, Guid>(dbContext),
    IWithdrawnLotsRepository;
