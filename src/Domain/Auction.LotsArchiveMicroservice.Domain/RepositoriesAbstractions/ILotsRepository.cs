using Auction.Common.Domain.RepositoriesAbstractions.Base;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using System;

namespace Auction.LotsArchiveMicroservice.Domain.RepositoriesAbstractions;

public interface ILotsRepository
    : IBaseRepository<Lot, Guid>;
