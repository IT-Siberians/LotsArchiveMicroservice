using Auction.Common.Application.RepositoriesAbstractions.Base;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using System;

namespace Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;

public interface IPersonsRepository
    : IBaseRepositoryWithDelete<Person, Guid>;
