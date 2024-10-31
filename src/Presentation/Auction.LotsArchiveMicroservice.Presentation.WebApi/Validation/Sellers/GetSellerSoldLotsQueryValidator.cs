using Auction.Common.Application.Interfaces.Commands;
using Auction.LotsArchive.Application.Commands.Sellers;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Sellers;

public class GetSellerSoldLotsQueryValidator : AbstractValidator<GetSellerSoldLotsQuery>
{
    public GetSellerSoldLotsQueryValidator(IValidator<PageQuery> pageQueryValidator)
    {
        RuleFor(e => e.SellerId)
            .NotEmpty();
        RuleFor(e => e.Page)
            .SetValidator(pageQueryValidator!)
            .When(customer => customer.Page != null);
    }
}
