using Auction.Common.Application.Commands;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using AutoMapper;

namespace Auction.Common.Application.Mapping;

public class CommonApplicationMappingProfile : Profile
{
    public CommonApplicationMappingProfile()
    {
        CreateMap<CreatePersonCommand, Person>();
    }
}
