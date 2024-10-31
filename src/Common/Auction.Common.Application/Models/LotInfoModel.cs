using System;

namespace Auction.Common.Application.Models;

public record LotInfoModel(
        Guid Id,
        string Title,
        string Description)
            : IModel<Guid>;
