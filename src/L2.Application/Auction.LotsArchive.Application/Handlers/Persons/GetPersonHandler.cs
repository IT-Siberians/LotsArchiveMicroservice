using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Implementations;
using Auction.Common.Application.Models;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Persons;

public class GetPersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : GetByIdHandler<GetPersonQuery, Person, PersonInfoModel, IPersonsRepository>(
            "пользователь",
            repository,
            toModel: e => mapper.Map<PersonInfoModel>(e),
            includeProperties: null,
            useTracking: false);
