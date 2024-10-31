using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.Common.Application.Interfaces.Commands;

public record CreatePersonCommand(
        Guid Id,
        string Username)
            : IModel<Guid>;
