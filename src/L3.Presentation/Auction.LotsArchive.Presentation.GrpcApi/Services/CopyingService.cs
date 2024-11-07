using Auction.Common.Application.L2.Interfaces.Answers;
using Auction.Common.Application.L2.Interfaces.Handlers;
using Auction.Common.Application.L2.Interfaces.Strings;
using Auction.LotsArchive.Application.L1.Models.Copying;
using Auction.LotsArchive.Application.L2.Interfaces.Commands.Copying;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Auction.LotsArchive.Presentation.GrpcApi.Services;

public class CopyingService(
    IQueryHandler<GetLotCopyQuery, LotCopyModel> handler)
        : Copying.CopyingBase
{
    public override async Task<GetLotCopyResponseGrpc> GetLotCopy(GetLotCopyQueryGrpc request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.SellerId, out _))
        {
            return GetErrorResponseGrpc($"ѕередано значение SellerId не соответствующее формату Guid: {request.SellerId}");
        }
        if (!Guid.TryParse(request.LotId, out _))
        {
            return GetErrorResponseGrpc($"ѕередано значение LotId не соответствующее формату Guid: {request.LotId}");
        }

        var query = new GetLotCopyQuery(new Guid(request.SellerId), new Guid(request.LotId));
        var answer = await handler.HandleAsync(query, context.CancellationToken);

        if (answer is IOkAnswer<LotCopyModel> okAnswer)
        {
            return new GetLotCopyResponseGrpc
            {
                IsError = false,
                ErrorMessage = "Ok",
                LotCopy = new LotCopyModelGrpc
                {
                    LotInfo = new LotInfoModelGrpc
                    {
                        Id = okAnswer.Result.LotInfo.Id.ToString(),
                        Title = okAnswer.Result.LotInfo.Title,
                        Description = okAnswer.Result.LotInfo.Description
                    },
                    LotParams = new LotParamsModelGrpc
                    {
                        StartingPrice = (double)okAnswer.Result.LotParams.StartingPrice,
                        BidIncrement = (double)okAnswer.Result.LotParams.BidIncrement,
                        RepurchasePrice = (double?)okAnswer.Result.LotParams.RepurchasePrice,
                        StartDateTime = Timestamp.FromDateTime(okAnswer.Result.LotParams.StartDateTime),
                        EndDateTime = Timestamp.FromDateTime(okAnswer.Result.LotParams.EndDateTime)
                    }
                }
            };
        }

        var errorMessage = answer switch
        {
            IBadAnswer badAnswer => badAnswer.ErrorMessage ?? CommonMessages.UnknownError,
            _ => CommonMessages.UnknownError
        };

        return GetErrorResponseGrpc(errorMessage);
    }

    private static GetLotCopyResponseGrpc GetErrorResponseGrpc(string errorMessage)
    {
        return new GetLotCopyResponseGrpc
        {
            IsError = true,
            ErrorMessage = errorMessage,
            LotCopy = new LotCopyModelGrpc
            {
                LotInfo = new LotInfoModelGrpc(),
                LotParams = new LotParamsModelGrpc()
            }
        };
    }
}
