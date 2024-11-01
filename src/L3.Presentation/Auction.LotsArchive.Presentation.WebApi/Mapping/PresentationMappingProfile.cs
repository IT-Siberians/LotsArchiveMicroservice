using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.Interfaces.Commands.Buyers;
using Auction.LotsArchive.Application.Interfaces.Commands.Sellers;
using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;
using AutoMapper;

namespace Auction.LotsArchive.Presentation.WebApi.Mapping;

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
