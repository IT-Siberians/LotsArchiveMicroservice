﻿using Auction.LotsArchive.Application.L1.Models.Archiving;
using System;

namespace Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;

public record AddWithdrawnLotCommandWeb(
    LotModel Lot,
    DateTime DateTime);
