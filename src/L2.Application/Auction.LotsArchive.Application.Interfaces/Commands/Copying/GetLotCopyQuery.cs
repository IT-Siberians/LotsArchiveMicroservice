using System;

namespace Auction.LotsArchive.Application.Interfaces.Commands.Copying;

public record GetLotCopyQuery(
    Guid SellerId,
    Guid LotId);
