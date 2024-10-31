using System;

namespace Auction.Common.Application.Models;

public record IdModel(
        Guid Id)
            : IModel<Guid>;
