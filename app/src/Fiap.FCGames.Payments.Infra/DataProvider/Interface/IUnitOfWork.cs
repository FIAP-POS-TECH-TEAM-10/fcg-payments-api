namespace Fiap.FCGames.Payments.Infra.DataProvider.Interface;

public interface IUnitOfWork
{
    IUsuarioRepository UsuarioRepository { get; }
    IBibliotecaJogosRepository BibliotecaJogosRepository { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
