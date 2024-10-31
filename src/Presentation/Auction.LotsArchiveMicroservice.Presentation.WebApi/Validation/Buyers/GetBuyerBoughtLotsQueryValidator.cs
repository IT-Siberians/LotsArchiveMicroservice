﻿using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Commands.Buyers;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Buyers;

public class GetBuyerBoughtLotsQueryValidator : AbstractValidator<GetBuyerBoughtLotsQuery>
{
    public GetBuyerBoughtLotsQueryValidator(IValidator<PageQuery> pageQueryValidator)
    {
        RuleFor(e => e.BuyerId)
            .NotEmpty();
        RuleFor(e => e.Page)
            .SetValidator(pageQueryValidator!)
            .When(customer => customer.Page != null);
    }
}
