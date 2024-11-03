using Auction.LotsArchive.Application.L2.Interfaces.Commands.Copying;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Copying;

public class GetLotCopyQueryValidator : AbstractValidator<GetLotCopyQuery>
{
    public GetLotCopyQueryValidator()
    {
        RuleFor(e => e.SellerId)
            .NotEmpty();
        RuleFor(e => e.LotId)
            .NotEmpty();
    }
}
