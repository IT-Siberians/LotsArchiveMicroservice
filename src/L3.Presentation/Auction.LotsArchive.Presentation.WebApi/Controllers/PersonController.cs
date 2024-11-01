using Auction.Common.Application.Interfaces.Commands;
using Auction.Common.Presentation.Contracts;
using Auction.Common.Presentation.Controllers;
using AutoMapper;

namespace Auction.LotsArchive.Presentation.WebApi.Controllers;

public class PersonController(IMapper mapper)
        : CreateDeleteApiController<CreatePersonCommandHttp, CreatePersonCommand, DeletePersonCommand>(mapper);
