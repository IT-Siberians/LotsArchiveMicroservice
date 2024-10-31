using Auction.LotsArchive.Application.Commands.Copying;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Copying;

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
