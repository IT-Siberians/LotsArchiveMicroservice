using Auction.Common.Application.Handlers;
using Auction.Common.Application.Interfaces.Commands;
using Auction.Common.Application.Interfaces.Models;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchive.Application.Handlers.Persons;

public class GetPersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : GetByIdHandler<GetPersonQuery, Person, PersonInfoModel, IPersonsRepository>(
            "пользователь",
            repository,
            toModel: e => mapper.Map<PersonInfoModel>(e),
            includeProperties: null,
            useTracking: false);
