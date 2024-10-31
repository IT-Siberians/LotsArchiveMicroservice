using Auction.Common.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;

public class LotsRepository(ApplicationDbContext dbContext)
    : BaseEfRepository<ApplicationDbContext, Lot, Guid>(dbContext),
    ILotsRepository;
