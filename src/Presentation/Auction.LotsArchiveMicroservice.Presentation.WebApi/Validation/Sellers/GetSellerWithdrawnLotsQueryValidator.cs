using Auction.Common.Application.Commands;
using Auction.LotsArchiveMicroservice.Application.Commands.Sellers;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Sellers;

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
