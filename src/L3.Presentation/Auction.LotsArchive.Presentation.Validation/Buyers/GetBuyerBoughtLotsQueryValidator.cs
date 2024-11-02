using Auction.Common.Application.L2.Interfaces.Commands;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Buyers;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Buyers;

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
