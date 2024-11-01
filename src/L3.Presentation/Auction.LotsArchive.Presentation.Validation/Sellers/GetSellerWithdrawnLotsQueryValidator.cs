using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Interfaces.Commands.Sellers;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Sellers;

public class GetSellerWithdrawnLotsQueryValidator : AbstractValidator<GetSellerWithdrawnLotsQuery>
{
    public GetSellerWithdrawnLotsQueryValidator(IValidator<PageQuery> pageQueryValidator)
    {
        RuleFor(e => e.SellerId)
            .NotEmpty();
        RuleFor(e => e.Page)
            .SetValidator(pageQueryValidator!)
            .When(customer => customer.Page != null);
    }
}
