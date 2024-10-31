using Auction.Common.Application.Handlers.Implementations;
using Auction.LotsArchiveMicroservice.Application.Commands.Sellers;
using Auction.LotsArchiveMicroservice.Application.Models.Sellers;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using AutoMapper;
using System;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Sellers;

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
        Filter = e => Query == null ||
                        (e.Seller.Id == Query.SellerId
                        && e.IsUnpurchased
                        && (Query.Filter == null || Query.Filter.With == null || Query.Filter.With == ""
                                                        || e.Title.Value.Contains(Query.Filter.With)
                                                        || e.Description.Value.Contains(Query.Filter.With))
                        && (Query.Filter == null || Query.Filter.Without == null || Query.Filter.Without == ""
                                                        || (!e.Title.Value.Contains(Query.Filter.Without)
                                                                && !e.Description.Value.Contains(Query.Filter.Without))));
    }
}
