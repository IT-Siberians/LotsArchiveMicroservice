using Auction.Common.Application.Models;
using System;

namespace Auction.Common.Application.Commands;

public record GetPersonQuery(Guid Id)
        : IModel<Guid>;
