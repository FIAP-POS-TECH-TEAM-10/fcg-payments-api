namespace Fiap.FCGames.Payments.Infra.DataProvider.Interface;

public interface IUnitOfWork
{
    IPagamentoRepository PagamentoRepository { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
