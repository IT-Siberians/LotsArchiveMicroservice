using Auction.Common.Application.Answers;
using Auction.Common.Application.Handlers.Abstractions;
using Auction.LotsArchiveMicroservice.Application.Commands.Copying;
using Auction.LotsArchiveMicroservice.Application.Models.Copying;
using Auction.LotsArchiveMicroservice.Application.RepositoriesAbstractions;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auction.LotsArchiveMicroservice.Application.Handlers.Copying;

public class GetLotCopyHandler(
    IPersonsRepository personsRepository,
    ILotsRepository lotsRepository,
    IMapper mapper)
        : IQueryHandler<GetLotCopyQuery, LotCopyModel>,
        IDisposable
{
    private readonly IPersonsRepository _personsRepository = personsRepository ?? throw new ArgumentNullException(nameof(personsRepository));
    private readonly ILotsRepository _lotsRepository = lotsRepository ?? throw new ArgumentNullException(nameof(lotsRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _personsRepository.Dispose();
            _lotsRepository.Dispose();

            _isDisposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public async Task<IAnswer<LotCopyModel>> HandleAsync(GetLotCopyQuery query, CancellationToken cancellationToken = default)
    {
        var person = await _personsRepository.GetByIdAsync(query.SellerId, cancellationToken: cancellationToken);
        if (person is null)
        {
            return BadAnswer<LotCopyModel>.EntityNotFound($"Не существует пользователь с Id = {query.SellerId}");
        }

        var lot = await _lotsRepository.GetByIdAsync(query.LotId, includeProperties: "Seller", cancellationToken: cancellationToken);

        if (lot is null || lot.Seller.Id != person.Id)
        {
            return BadAnswer<LotCopyModel>.EntityNotFound($"Не существует лот с Id = {query.LotId}");
        }

        var lotModel = _mapper.Map<LotCopyModel>(lot); ;

        return new OkAnswer<LotCopyModel>(lotModel);
    }
}
