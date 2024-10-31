using System;

namespace Auction.Common.Application.Interfaces.Models;

public record PersonInfoModel(
        Guid Id,
        string Username)
            : IModel<Guid>;
