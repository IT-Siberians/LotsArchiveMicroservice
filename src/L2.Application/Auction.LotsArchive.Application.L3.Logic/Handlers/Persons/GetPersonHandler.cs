using Auction.Common.Application.L1.Models;
using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Strings;
using Auction.Common.Application.L3.Logic.Handlers;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Persons;

public class GetPersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : GetByIdHandler<GetPersonQuery, Person, PersonInfoModel, IPersonsRepository>(
            CommonNames.User,
            repository,
            toModel: e => mapper.Map<PersonInfoModel>(e),
            includeProperties: null,
            useTracking: false);
