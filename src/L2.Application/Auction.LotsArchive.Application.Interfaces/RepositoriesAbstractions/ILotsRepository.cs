using Auction.Common.Application.RepositoriesAbstractions.Base;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using System;

namespace Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;

public interface ILotsRepository
    : IBaseRepository<Lot, Guid>;
