using Auction.LotsArchive.Application.Commands.Archiving;
using Auction.LotsArchive.Application.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Archiving;

public class AddUnpurchasedLotCommandValidator : AbstractValidator<AddUnpurchasedLotCommand>
{
    public AddUnpurchasedLotCommandValidator(
        IValidator<LotModel> lotModelValidator)
    {
        RuleFor(e => e.Lot)
            .NotEmpty()
            .SetValidator(lotModelValidator!);
    }
}
