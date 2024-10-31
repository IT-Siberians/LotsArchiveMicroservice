using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Commands.Archiving;
using Auction.LotsArchive.Application.Commands.Buyers;
using Auction.LotsArchive.Application.Commands.Sellers;
using Auction.LotsArchive.Application.Models.Archiving;
using Auction.LotsArchiveMicroservice.Presentation.WebApi.Contracts.Archiving;
using AutoMapper;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Mapping;

public class PresentationMappingProfile : Profile
{
    public PresentationMappingProfile()
    {
        CreateMap<LotModelHttp, LotModel>();
        CreateMap<PurchasingInfoModelHttp, PurchasingInfoModel>();

        CreateMap<AddRepurchasedLotCommandHttp, AddRepurchasedLotCommand>();
        CreateMap<AddUnpurchasedLotCommandHttp, AddUnpurchasedLotCommand>();
        CreateMap<AddWithdrawnLotCommandHttp, AddWithdrawnLotCommand>();

        CreateMap<GetItemsPageByIdQuery, GetBuyerBoughtLotsQuery>()
            .ConstructUsing(x => new GetBuyerBoughtLotsQuery(x.Id, x.Page, x.Filter));
        CreateMap<GetItemsPageByIdQuery, GetSellerSoldLotsQuery>()
            .ConstructUsing(x => new GetSellerSoldLotsQuery(x.Id, x.Page, x.Filter));
        CreateMap<GetItemsPageByIdQuery, GetSellerUnpurchasedLotsQuery>()
            .ConstructUsing(x => new GetSellerUnpurchasedLotsQuery(x.Id, x.Page, x.Filter));
        CreateMap<GetItemsPageByIdQuery, GetSellerWithdrawnLotsQuery>()
            .ConstructUsing(x => new GetSellerWithdrawnLotsQuery(x.Id, x.Page, x.Filter));
    }
}
