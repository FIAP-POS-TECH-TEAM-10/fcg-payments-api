using Fiap.FCGames.Payments.Domain.Aggregates.AggregatePagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.FCGames.Payments.Infra.DataProvider.EntityConfigurations;

public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("Pagamentos");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.PedidoId).IsUnique();
        builder.Property(p => p.PedidoId).IsRequired();
        builder.Property(p => p.UsuarioId).IsRequired();
        builder.Property(p => p.JogoId).IsRequired();
        builder.Property(p => p.Valor).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.Motivo);
        builder.Property(p => p.ProcessadoEm).IsRequired();
    }
}
