﻿using Auction.Common.Application.Commands;
using Auction.Common.Presentation.Contracts;
using Auction.Common.Presentation.Controllers;
using AutoMapper;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Controllers;

public class PersonController(IMapper mapper)
        : CreateDeleteApiController<CreatePersonCommandHttp, CreatePersonCommand, DeletePersonCommand>(mapper);
