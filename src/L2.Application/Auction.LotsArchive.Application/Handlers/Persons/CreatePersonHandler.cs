using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Implementations;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;
using AutoMapper;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Persons;

public class CreatePersonHandler(
    IPersonsRepository repository,
    IMapper mapper)
        : CreateHandler<CreatePersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository,
            mapper);
