using System;

namespace Auction.Common.Application.Interfaces.Models;

public record IdModel(
        Guid Id)
            : IModel<Guid>;
