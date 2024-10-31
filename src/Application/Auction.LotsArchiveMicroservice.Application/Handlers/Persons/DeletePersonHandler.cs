using Auction.Common.Application.Commands;
using Auction.Common.Application.Handlers.Implementations;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using Auction.LotsArchiveMicroservice.Domain.Entities;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Persons;

public class DeletePersonHandler(
    IPersonsRepository repository)
        : DeleteHandler<DeletePersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository);
