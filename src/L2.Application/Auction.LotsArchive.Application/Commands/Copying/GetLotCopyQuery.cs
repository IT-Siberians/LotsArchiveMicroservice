using System;

namespace Auction.LotsArchive.Application.Commands.Copying;

public record GetLotCopyQuery(
    Guid SellerId,
    Guid LotId);
