using Auction.Common.Application.Models;
using System;

namespace Auction.Common.Application.Commands;

public record CreatePersonCommand(
        Guid Id,
        string Username)
            : IModel<Guid>;
