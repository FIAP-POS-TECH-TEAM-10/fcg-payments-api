using Fiap.FCGames.Payments.Infra.DataProvider.Contexto;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;

namespace Fiap.FCGames.Payments.Infra.DataProvider.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly FcGamesContexto _context;
    public IPagamentoRepository PagamentoRepository { get; }

    public UnitOfWork(FcGamesContexto context, IPagamentoRepository pagamentoRepository)
    {
        _context = context;
        PagamentoRepository = pagamentoRepository;
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);
}
