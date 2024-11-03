using Auction.LotsArchive.Application.L1.Models.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
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
