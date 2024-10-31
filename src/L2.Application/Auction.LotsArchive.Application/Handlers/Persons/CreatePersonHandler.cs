using Auction.Common.Application.Handlers;
using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchive.Application.Handlers.Persons;

public class CreatePersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : CreateHandler<CreatePersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository,
            mapper);
