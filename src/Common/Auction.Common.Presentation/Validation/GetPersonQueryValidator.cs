using Auction.Common.Application.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
