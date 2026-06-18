using Fiap.FCGames.Payments.Domain.Aggregates;

namespace Fiap.FCGames.Payments.Infra.DataProvider.Interface;

public interface IBibliotecaJogosRepository
{
    void Adicionar(BibliotecaJogos biblioteca);
    Task<BibliotecaJogos?> ObterPorUsuarioIdAsync(UsuarioId usuarioId);
}
