using Auction.Common.Application.Commands;
using FluentValidation;

namespace Auction.Common.Presentation.Validation;

public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty();
    }
}
