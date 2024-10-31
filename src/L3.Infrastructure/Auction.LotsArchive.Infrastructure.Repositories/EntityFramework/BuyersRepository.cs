using Auction.Common.Infrastructure.RepositoriesImplementations.EntityFramework;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchiveMicroservice.Infrastructure.RepositoriesImplementations.EntityFramework;

public class BuyersRepository(ApplicationDbContext dbContext)
    : BaseEfRepository<ApplicationDbContext, Buyer, Guid>(dbContext),
    IBuyersRepository;
