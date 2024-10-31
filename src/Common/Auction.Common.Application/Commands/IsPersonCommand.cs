using Auction.Common.Application.Models;
using System;

namespace Auction.Common.Application.Commands;

public record IsPersonCommand(Guid Id)
        : IModel<Guid>;
