using Auction.Common.Application.Handlers;
using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;

namespace Auction.LotsArchive.Application.Handlers.Persons;

public class DeletePersonHandler(
    IPersonsRepository repository)
        : DeleteHandler<DeletePersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository);
