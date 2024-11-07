using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L3.Logic.Handlers;
using Auction.Common.Application.L3.Logic.Strings;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Persons;

public class CreatePersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : CreateHandler<CreatePersonCommand, Person, IPersonsRepository>(
            Names.User,
            repository,
            mapper);
