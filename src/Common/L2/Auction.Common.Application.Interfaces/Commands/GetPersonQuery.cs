using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.Common.Application.Interfaces.Commands;

public record GetPersonQuery(Guid Id)
        : IModel<Guid>;
