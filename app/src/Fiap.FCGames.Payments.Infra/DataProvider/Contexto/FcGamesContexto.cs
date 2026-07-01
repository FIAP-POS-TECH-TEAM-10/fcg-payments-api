using Fiap.FCGames.Payments.Domain.Aggregates.AggregatePagamento;
using Fiap.FCGames.Payments.Infra.DataProvider.EntityConfigurations;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Fiap.FCGames.Payments.Infra.DataProvider.Contexto;

public class FcGamesContexto : DbContext
{
    public FcGamesContexto(DbContextOptions<FcGamesContexto> options) : base(options) { }

    public DbSet<Pagamento> Pagamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PagamentoConfiguration());

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}
