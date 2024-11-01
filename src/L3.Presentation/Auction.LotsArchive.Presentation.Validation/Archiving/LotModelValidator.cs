using Auction.Common.Domain.ValueObjects.String;
using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Archiving;

public class LotModelValidator : AbstractValidator<LotModel>
{
    public LotModelValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
        RuleFor(e => e.SellerId)
            .NotEmpty();
        RuleFor(e => e.Title)
            .NotEmpty()
            .MinimumLength(Title.MinLength)
            .MaximumLength(Title.MaxLength)
            .Matches(Username.Pattern);
        RuleFor(e => e.Description)
            .NotEmpty()
            .MinimumLength(1);
        RuleFor(e => e.StartingPrice)
            .GreaterThan(0);
        RuleFor(e => e.BidIncrement)
            .GreaterThan(0);
        RuleFor(e => e.RepurchasePrice)
            .GreaterThan(0)
            .When(customer => customer.RepurchasePrice != null);
    }
}
