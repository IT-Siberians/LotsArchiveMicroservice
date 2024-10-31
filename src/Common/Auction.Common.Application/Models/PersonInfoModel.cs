using System;

namespace Auction.Common.Application.Models;

public record PersonInfoModel(
        Guid Id,
        string Username)
            : IModel<Guid>;
