using System;

namespace Auction.LotsArchiveMicroservice.Application.Commands.Copying;

public record GetLotCopyQuery(
    Guid SellerId,
    Guid LotId);
