using Fiap.FCGames.Payments.Domain.Aggregates.AggregatePagamento;

namespace Fiap.FCGames.Payments.Infra.DataProvider.Interface;

public interface IPagamentoRepository
{
    Task<Pagamento?> ObterPorPedidoIdAsync(Guid pedidoId);
    void Adicionar(Pagamento pagamento);
}
