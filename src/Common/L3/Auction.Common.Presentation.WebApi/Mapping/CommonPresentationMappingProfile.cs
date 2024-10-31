using Auction.Common.Application.Interfaces.Commands;
using Auction.Common.Application.Interfaces.Models;
using Auction.Common.Presentation.Contracts;
using AutoMapper;

namespace Auction.Common.Presentation.Mapping;

public class CommonPresentationMappingProfile : Profile
{
    public CommonPresentationMappingProfile()
    {
        CreateMap<CreatePersonCommandHttp, CreatePersonCommand>();
        CreateMap<IdModel, DeletePersonCommand>();
        CreateMap<IdModel, GetPersonQuery>();
        CreateMap<IdModel, IsPersonCommand>();
    }
}