using Auction.LotsArchive.Application.L1.Models.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Archiving;

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
