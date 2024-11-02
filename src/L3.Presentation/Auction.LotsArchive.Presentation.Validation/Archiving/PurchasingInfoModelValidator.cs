﻿using Auction.LotsArchive.Application.L1.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Archiving;

public class PurchasingInfoModelValidator : AbstractValidator<PurchasingInfoModel>
{
    public PurchasingInfoModelValidator()
    {
        RuleFor(e => e.BuyerId)
            .NotEmpty();
        RuleFor(e => e.HammerPrice)
            .GreaterThan(0);
    }
}
