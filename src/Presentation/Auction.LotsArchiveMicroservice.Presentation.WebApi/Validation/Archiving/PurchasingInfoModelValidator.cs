using Auction.LotsArchiveMicroservice.Application.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Archiving;

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
