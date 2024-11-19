﻿using Auction.Common.Application.L3.Logic.Handlers;
using Auction.LotsArchive.Application.L1.Models.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;
using System;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Sellers;

public class GetSellerWithdrawnLotsHandler
    : GetPageHandler<GetSellerWithdrawnLotsQuery, WithdrawnLot, WithdrawnLotModel, IWithdrawnLotsRepository, DateTime>
{
    public GetSellerWithdrawnLotsHandler(
        IWithdrawnLotsRepository repository,
        IMapper mapper)
            : base(
                repository,
                toModel: mapper.Map<WithdrawnLotModel>, // Здесь AutoMapper справляется!
                                                        //toModel: e => new WithdrawnLotModel(
                                                        //    mapper.Map<LotInfoModel>(e.Lot),
                                                        //    new LotParamsModel(
                                                        //        e.Lot.StartingPrice.Value,
                                                        //        e.Lot.BidIncrement.Value,
                                                        //        e.Lot.RepurchasePrice?.Value,
                                                        //        e.Lot.StartDateTime,
                                                        //        e.Lot.EndDateTime),
                                                        //    e.DateTime),
                orderKeySelector: e => e.DateTime,
                includeProperties: "Lot.Seller",
                useTracking: false)
    {
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
        Filters =
        [
            e => Query == null || e.Lot.Seller.Id == Query.SellerId,
            e => Query == null || Query.Filter == null || Query.Filter.With == null || Query.Filter.With == ""
                                                        || e.Lot.Title.Value.ToLower().Contains(Query.Filter.With)
                                                        || e.Lot.Description.Value.ToLower().Contains(Query.Filter.With),
            e => Query == null || Query.Filter == null || Query.Filter.Without == null || Query.Filter.Without == ""
                                                        || (!e.Lot.Title.Value.ToLower().Contains(Query.Filter.Without)
                                                            && !e.Lot.Description.Value.ToLower().Contains(Query.Filter.Without))
        ];
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
    }
}
