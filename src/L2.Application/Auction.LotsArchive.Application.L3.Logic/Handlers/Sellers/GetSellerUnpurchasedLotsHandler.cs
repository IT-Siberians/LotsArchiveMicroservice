﻿using Auction.Common.Application.L3.Logic.Handlers;
using Auction.LotsArchive.Application.L1.Models.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;
using System;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Sellers;

public class GetSellerUnpurchasedLotsHandler
    : GetPageHandler<GetSellerUnpurchasedLotsQuery, Lot, UnpurchasedLotModel, ILotsRepository, DateTime>
{
    public GetSellerUnpurchasedLotsHandler(
        ILotsRepository repository,
        IMapper mapper)
            : base(
                repository,
                toModel: mapper.Map<UnpurchasedLotModel>,  // Здесь AutoMapper справляется!
                                                           //toModel: e => new UnpurchasedLotModel(
                                                           //    mapper.Map<LotInfoModel>(e),
                                                           //    new LotParamsModel(
                                                           //        e.StartingPrice.Value,
                                                           //        e.BidIncrement.Value,
                                                           //        e.RepurchasePrice?.Value,
                                                           //        e.StartDateTime,
                                                           //        e.EndDateTime)),
                orderKeySelector: e => e.EndDateTime,
                includeProperties: "Seller",
                useTracking: false)
    {
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
        Filters =
        [
            e => Query == null || e.Seller.Id == Query.SellerId,
            e => e.IsUnpurchased,
            e => Query == null || Query.Filter == null || Query.Filter.With == null || Query.Filter.With == ""
                                                        || e.Title.Value.ToLower().Contains(Query.Filter.With)
                                                        || e.Description.Value.ToLower().Contains(Query.Filter.With),
            e => Query == null || Query.Filter == null || Query.Filter.Without == null || Query.Filter.Without == ""
                                                        || (!e.Title.Value.ToLower().Contains(Query.Filter.Without)
                                                                && !e.Description.Value.ToLower().Contains(Query.Filter.Without))
        ];
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
    }
}
