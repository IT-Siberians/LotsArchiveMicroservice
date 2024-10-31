using Auction.Common.Infrastructure.Repositories.EntityFramework;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using Auction.LotsArchive.Infrastructure.EntityFramework;
using System;

namespace Auction.LotsArchive.Infrastructure.Repositories.EntityFramework;

public class RepurchasedLotsRepository(ApplicationDbContext dbContext)
    : BaseEfRepository<ApplicationDbContext, RepurchasedLot, Guid>(dbContext),
    IRepurchasedLotsRepository;
