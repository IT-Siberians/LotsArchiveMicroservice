using Auction.LotsArchive.Application.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Archiving;

public class AddWithdrawnLotCommandValidator : AbstractValidator<AddWithdrawnLotCommand>
{
    public AddWithdrawnLotCommandValidator(
        IValidator<LotModel> lotModelValidator)
    {
        RuleFor(e => e.Lot)
            .NotEmpty()
            .SetValidator(lotModelValidator!);
    }
}
