using Fiap.FCGames.Payments.Domain.Aggregates.AggregatePagamento;
using Fiap.FCGames.Payments.Infra.DataProvider.Contexto;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using Fiap.FCGames.Payments.Infra.DataProvider.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Fiap.FCGames.Payments.Infra.DataProvider.Repositories;

public class PagamentoRepository : GenericRepository<Pagamento>, IPagamentoRepository
{
    public PagamentoRepository(FcGamesContexto context) : base(context) { }

    public async Task<Pagamento?> ObterPorPedidoIdAsync(Guid pedidoId)
        => await Get(p => p.PedidoId == pedidoId).AsNoTracking().FirstOrDefaultAsync();

    public void Adicionar(Pagamento pagamento) => Create(pagamento);
}
