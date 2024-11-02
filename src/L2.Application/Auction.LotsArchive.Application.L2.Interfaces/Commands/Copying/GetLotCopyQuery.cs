using System;

namespace Auction.LotsArchive.Application.L2.Interfaces.Commands.Copying;

public record GetLotCopyQuery(
    Guid SellerId,
    Guid LotId);
