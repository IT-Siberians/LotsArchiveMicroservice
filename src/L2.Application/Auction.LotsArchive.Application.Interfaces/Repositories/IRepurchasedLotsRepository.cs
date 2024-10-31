using Auction.Common.Application.Interfaces.Repositories.Base;
using Auction.LotsArchive.Domain.Entities;
using System;

namespace Auction.LotsArchive.Application.Interfaces.Repositories;

public interface IRepurchasedLotsRepository
    : IBaseRepository<RepurchasedLot, Guid>;
