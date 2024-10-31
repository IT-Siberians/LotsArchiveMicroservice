using Auction.Common.Application.Handlers;
using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;

namespace Auction.LotsArchive.Application.Handlers.Persons;

public class IsPersonHandler(
    IPersonsRepository repository)
        : IsHandler<IsPersonCommand, Person, IPersonsRepository>(
            "пользователь",
            repository);
