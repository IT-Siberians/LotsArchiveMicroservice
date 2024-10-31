using Auction.Common.Application.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

public class IsPersonCommandValidator : AbstractValidator<IsPersonCommand>
{
    public IsPersonCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
