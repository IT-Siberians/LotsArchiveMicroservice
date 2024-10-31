using Auction.Common.Application.Handlers.Implementations;
using Auction.Common.Application.Models;
using Auction.LotsArchiveMicroservice.Application.Commands.Sellers;
using Auction.LotsArchiveMicroservice.Application.Models.Sellers;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using AutoMapper;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Sellers;

public class GetSellerSoldLotsHandler
    : GetPageHandler<GetSellerSoldLotsQuery, RepurchasedLot, SoldLotModel, IRepurchasedLotsRepository, DateTime>
{
    public GetSellerSoldLotsHandler(
        IRepurchasedLotsRepository repository,
        IMapper mapper)
            : base(
                repository,
                //toModel: mapper.Map<SoldLotModel>, // Так не работает! AutoMapper не справляется!
                toModel: e => new SoldLotModel(
                    mapper.Map<LotInfoModel>(e.Lot),
                    new LotParamsModel(
                        e.Lot.StartingPrice.Value,
                        e.Lot.BidIncrement.Value,
                        e.Lot.RepurchasePrice?.Value,
                        e.Lot.StartDateTime,
                        e.Lot.EndDateTime),
                    mapper.Map<PersonInfoModel>(e.Buyer.PersonInfo),
                    e.DateTime,
                    e.HammerPrice.Value),
                orderKeySelector: e => e.DateTime,
                includeProperties: "Lot.Seller, Buyer.PersonInfo",
                useTracking: false)
    {
        Filter = e => Query == null ||
                        (e.Lot.Seller.Id == Query.SellerId
                        && (Query.Filter == null || Query.Filter.With == null || Query.Filter.With == ""
                                                        || e.Lot.Title.Value.Contains(Query.Filter.With)
                                                        || e.Lot.Description.Value.Contains(Query.Filter.With)
                                                        || e.Buyer.PersonInfo.Username.Value.Contains(Query.Filter.With))
                        && (Query.Filter == null || Query.Filter.Without == null || Query.Filter.Without == ""
                                                        || (!e.Lot.Title.Value.Contains(Query.Filter.Without)
                                                                && !e.Lot.Description.Value.Contains(Query.Filter.Without)
                                                                && !e.Buyer.PersonInfo.Username.Value.Contains(Query.Filter.Without))));
    }
}
