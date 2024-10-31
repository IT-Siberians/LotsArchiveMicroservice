using System;

namespace Auction.Common.Application.Interfaces.Models;

public record LotInfoModel(
        Guid Id,
        string Title,
        string Description)
            : IModel<Guid>;
