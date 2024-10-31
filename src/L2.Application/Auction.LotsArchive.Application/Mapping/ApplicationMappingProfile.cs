using Auction.Common.Application.Interfaces.Commands;
using Auction.Common.Application.Interfaces.Models;
using Auction.LotsArchive.Application.Models.Copying;
using Auction.LotsArchive.Application.Models.Sellers;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchive.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<CreatePersonCommand, Person>();

        CreateMap<Person, PersonInfoModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.Value));
        CreateMap<Buyer, PersonInfoModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.PersonInfo.Username.Value));
        CreateMap<Seller, PersonInfoModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.PersonInfo.Username.Value));

        CreateMap<Lot, LotInfoModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value));

        CreateMap<Lot, LotParamsModel>()
            .ConstructUsing(e => new LotParamsModel(
                                        e.StartingPrice.Value,
                                        e.BidIncrement.Value,
                                        e.RepurchasePrice == null ? null : e.RepurchasePrice.Value,
                                        e.StartDateTime,
                                        e.EndDateTime));

        CreateMap<Lot, LotCopyModel>()
            .ConstructUsing(e => new LotCopyModel(
                                    new LotInfoModel(
                                        e.Id,
                                        e.Title.Value,
                                        e.Description.Value),
                                    new LotParamsModel(
                                        e.StartingPrice.Value,
                                        e.BidIncrement.Value,
                                        e.RepurchasePrice == null ? null : e.RepurchasePrice.Value,
                                        e.StartDateTime,
                                        e.EndDateTime)));

        CreateMap<Lot, UnpurchasedLotModel>()
            .ConstructUsing(e => new UnpurchasedLotModel(
                                    new LotInfoModel(
                                        e.Id,
                                        e.Title.Value,
                                        e.Description.Value),
                                    new LotParamsModel(
                                        e.StartingPrice.Value,
                                        e.BidIncrement.Value,
                                        e.RepurchasePrice == null ? null : e.RepurchasePrice.Value,
                                        e.StartDateTime,
                                        e.EndDateTime)));

        CreateMap<WithdrawnLot, WithdrawnLotModel>()
            .ConstructUsing(e => new WithdrawnLotModel(
                                    new LotInfoModel(
                                        e.Lot.Id,
                                        e.Lot.Title.Value,
                                        e.Lot.Description.Value),
                                    new LotParamsModel(
                                        e.Lot.StartingPrice.Value,
                                        e.Lot.BidIncrement.Value,
                                        e.Lot.RepurchasePrice == null ? null : e.Lot.RepurchasePrice.Value,
                                        e.Lot.StartDateTime,
                                        e.Lot.EndDateTime),
                                    e.DateTime));

        // Не работает !
        //CreateMap<RepurchasedLot, SoldLotModel>()
        //    .ConstructUsing(e => new SoldLotModel(
        //                            new LotInfoModel(
        //                                e.Lot.Id,
        //                                e.Lot.Title.Value,
        //                                e.Lot.Description.Value),
        //                            new LotParamsModel(
        //                                e.Lot.StartingPrice.Value,
        //                                e.Lot.BidIncrement.Value,
        //                                e.Lot.RepurchasePrice == null ? null : e.Lot.RepurchasePrice.Value,
        //                                e.Lot.StartDateTime,
        //                                e.Lot.EndDateTime),
        //                            new PersonInfoModel(
        //                                e.Buyer.Id,
        //                                e.Buyer.PersonInfo.Username.Value),
        //                            e.DateTime,
        //                            e.HammerPrice.Value));

        // Не работает !
        //CreateMap<RepurchasedLot, BoughtLotModel>()
        //    .ConstructUsing(e => new BoughtLotModel(
        //                            new LotInfoModel(
        //                                e.Lot.Id,
        //                                e.Lot.Title.Value,
        //                                e.Lot.Description.Value),
        //                            new PersonInfoModel(
        //                                e.Lot.Seller.Id,
        //                                e.Lot.Seller.PersonInfo.Username.Value),
        //                            e.DateTime,
        //                            e.HammerPrice.Value));
    }
}
