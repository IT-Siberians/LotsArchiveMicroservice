using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.LotsArchive.Application.L1.Models.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Buyers;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Sellers;
using Auction.LotsArchive.Presentation.WebApi.Contracts.Archiving;
using AutoMapper;

namespace Auction.LotsArchive.Presentation.WebApi.Mapping;

public class WebApiMappingProfile : Profile
{
    public WebApiMappingProfile()
    {
        CreateMap<LotModelWeb, LotModel>();
        CreateMap<PurchasingInfoModelWeb, PurchasingInfoModel>();

        CreateMap<AddRepurchasedLotCommandWeb, AddRepurchasedLotCommand>();
        CreateMap<AddUnpurchasedLotCommandWeb, AddUnpurchasedLotCommand>();
        CreateMap<AddWithdrawnLotCommandWeb, AddWithdrawnLotCommand>();

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
