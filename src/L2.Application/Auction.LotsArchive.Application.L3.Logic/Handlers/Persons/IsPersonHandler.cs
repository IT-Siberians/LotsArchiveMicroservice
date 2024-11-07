using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.Common.Application.L2.Interfaces.Strings;
using Auction.Common.Application.L3.Logic.Handlers;
using Auction.LotsArchive.Application.L2.Interfaces.Repositories;
using Auction.LotsArchive.Domain.Entities;

namespace Auction.LotsArchive.Application.L3.Logic.Handlers.Persons;

public class IsPersonHandler(
    IPersonsRepository repository)
        : IsHandler<IsPersonCommand, Person, IPersonsRepository>(
            CommonNames.User,
            repository);
