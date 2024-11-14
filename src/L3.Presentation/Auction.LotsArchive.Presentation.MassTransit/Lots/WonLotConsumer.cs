using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.LotsArchive.Application.L1.Models.Archiving;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Archiving;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Logging;
using Otus.QueueDto.Lot;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchive.Presentation.MassTransit.Lots;

public class WonLotConsumer(
    IValidator<AddRepurchasedLotCommand> validator,
    ICommandHandler<AddRepurchasedLotCommand> handler,
    ILogger<WonLotConsumer> logger)
        : IConsumer<WonLotEvent>
{
    public async Task Consume(ConsumeContext<WonLotEvent> context)
    {
        var command = new AddRepurchasedLotCommand(
            new LotModel(
                context.Message.LotId,
                context.Message.SellerId,
                context.Message.Title,
                context.Message.Description,
                context.Message.StartingPrice,
                context.Message.BidIncrement,
                context.Message.RepurchasePrice,
                context.Message.StartDateTime,
                context.Message.EndDateTime),
            new PurchasingInfoModel(
                DateTime.UtcNow,
                context.Message.CustomerId,
                context.Message.HammerPrice));

        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
        {
            var messages = $"{Environment.NewLine}{string.Join(Environment.NewLine, validationResult.Errors.Select(e => $"- {e.PropertyName}: {e.ErrorMessage}"))}";
            logger.LogError("Validation messages: {Messages}", messages);
            return;
        }

        var answer = await handler.HandleAsync(command, new CancellationToken());
        if (answer is BadAnswer badAnswer)
        {
            logger.LogError("Error message: {ErrorMessage}", badAnswer.ErrorMessage);
        }
        else
        {
            logger.LogInformation("Created lot: Id = {LotId}", command.Lot.Id);
        }
    }
}
