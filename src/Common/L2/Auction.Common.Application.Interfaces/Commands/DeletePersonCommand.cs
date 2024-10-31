using Auction.Common.Application.Models;
using System;

namespace Auction.Common.Application.Commands;

public record DeletePersonCommand(Guid Id)
        : IModel<Guid>;
