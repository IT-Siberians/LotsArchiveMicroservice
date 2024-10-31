using Auction.LotsArchiveMicroservice.Application.Commands.Archiving;
using Auction.LotsArchiveMicroservice.Application.Models.Archiving;
using FluentValidation;

namespace Auction.LotsArchiveMicroservice.Presentation.WebApi.Validation.Archiving;

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
