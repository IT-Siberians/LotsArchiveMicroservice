using Auction.Common.Application.Interfaces.Models;
using System;

namespace Auction.Common.Application.Interfaces.Commands;

public record IsPersonCommand(Guid Id)
        : IModel<Guid>;
