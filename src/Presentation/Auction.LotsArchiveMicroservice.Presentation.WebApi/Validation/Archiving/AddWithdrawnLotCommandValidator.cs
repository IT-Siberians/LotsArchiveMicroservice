using Auction.LotsArchiveMicroservice.Application.Commands.Archiving;
using Auction.LotsArchiveMicroservice.Application.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Archiving;

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
