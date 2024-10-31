using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Commands.Sellers;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Sellers;

public class GetSellerUnpurchasedLotsQueryValidator : AbstractValidator<GetSellerUnpurchasedLotsQuery>
{
    public GetSellerUnpurchasedLotsQueryValidator(IValidator<PageQuery> pageQueryValidator)
    {
        RuleFor(e => e.SellerId)
            .NotEmpty();
        RuleFor(e => e.Page)
            .SetValidator(pageQueryValidator!)
            .When(customer => customer.Page != null);
    }
}
