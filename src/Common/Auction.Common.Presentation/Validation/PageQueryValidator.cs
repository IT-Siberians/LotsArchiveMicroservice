﻿using Auction.Common.Application.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

public class PageQueryValidator : AbstractValidator<PageQuery>
{
    public PageQueryValidator()
    {
        RuleFor(e => e.ItemsCount)
            .GreaterThanOrEqualTo(1);
        RuleFor(e => e.Number)
            .GreaterThanOrEqualTo(1); ;
    }
}
