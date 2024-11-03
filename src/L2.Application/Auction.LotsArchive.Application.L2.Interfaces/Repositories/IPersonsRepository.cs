using Auction.Common.Application.L2.Interfaces.Repositories.Base;
using Auction.LotsArchive.Domain.Entities;
using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Repositories;

public interface IPersonsRepository
    : IBaseRepositoryWithDelete<Person, Guid>;
