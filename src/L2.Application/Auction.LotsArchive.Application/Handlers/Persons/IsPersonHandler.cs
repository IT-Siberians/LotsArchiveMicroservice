using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Implementations;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Persons;

public class IsPersonHandler(
    IPersonsRepository repository)
        : IsHandler<IsPersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository);
