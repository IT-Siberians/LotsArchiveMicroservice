using Auction.Common.Application.Handlers;
using Auction.Common.Application.Interfaces.Models;
using Auction.LotsArchive.Application.Interfaces.Commands.Buyers;
using Auction.LotsArchive.Application.Interfaces.Models.Buyers;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;
using System;

namespace Auction.LotsArchive.Application.Handlers.Buyers;

public class GetBuyerBoughtLotsHandler
        : GetPageHandler<GetBuyerBoughtLotsQuery, RepurchasedLot, BoughtLotModel, IRepurchasedLotsRepository, DateTime>
{
    public GetBuyerBoughtLotsHandler(
        IRepurchasedLotsRepository repository,
        IMapper mapper)
            : base(
                repository,
                //toModel: mapper.Map<BoughtLotModel>, // Так не работает! AutoMapper не справляется!
                toModel: e => new BoughtLotModel(
                    mapper.Map<LotInfoModel>(e.Lot),
                    mapper.Map<PersonInfoModel>(e.Lot.Seller.PersonInfo),
                    e.DateTime,
                    e.HammerPrice.Value),
                orderKeySelector: e => e.DateTime,
                includeProperties: "Lot.Seller.PersonInfo",
                useTracking: false)
    {
        Filter = e => Query == null ||
                        e.Buyer.Id == Query.BuyerId
                        && (Query.Filter == null || Query.Filter.With == null || Query.Filter.With == ""
                                                        || e.Lot.Title.Value.Contains(Query.Filter.With)
                                                        || e.Lot.Description.Value.Contains(Query.Filter.With)
                                                        || e.Lot.Seller.PersonInfo.Username.Value.Contains(Query.Filter.With))
                        && (Query.Filter == null || Query.Filter.Without == null || Query.Filter.Without == ""
                                                        || !e.Lot.Title.Value.Contains(Query.Filter.Without)
                                                                && !e.Lot.Description.Value.Contains(Query.Filter.Without)
                                                                && !e.Lot.Seller.PersonInfo.Username.Value.Contains(Query.Filter.Without));
    }
}
