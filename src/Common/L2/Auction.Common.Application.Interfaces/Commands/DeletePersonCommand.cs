using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.Common.Application.Interfaces.Commands;

public record DeletePersonCommand(Guid Id)
        : IModel<Guid>;
