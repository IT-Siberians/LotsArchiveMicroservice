using Auction.LotsArchive.Application.Interfaces.Commands.Archiving;
using Auction.LotsArchive.Application.Interfaces.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchive.Presentation.Validation.Archiving;

public class AddRepurchasedLotCommandValidator : AbstractValidator<AddRepurchasedLotCommand>
{
    public AddRepurchasedLotCommandValidator(
        IValidator<LotModel> lotModelValidator,
        IValidator<PurchasingInfoModel> purchasingInfoModel)
    {
        RuleFor(e => e.Lot)
            .NotEmpty()
            .SetValidator(lotModelValidator!);
        RuleFor(e => e.PurchasingInfo)
            .NotEmpty()
            .SetValidator(purchasingInfoModel!);
    }
}
