using Fiap.FCGames.Payments.Domain.Exception;
using Fiap.FCGames.Payments.Domain.Aggregates;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using MediatR;

namespace Fiap.FCGames.Payments.Application.Queries.Usuario.BuscarUsuarioPorId;

public class BuscarUsuarioPorIdQueryHandler : IRequestHandler<BuscarUsuarioPorIdQuery, DetalhesUsuarioDto>
{
    private readonly IUsuarioRepository _usuarioRepo;

    public BuscarUsuarioPorIdQueryHandler(IUsuarioRepository usuarioRepo)
    {
        _usuarioRepo = usuarioRepo;
    }

    public async Task<DetalhesUsuarioDto> Handle(BuscarUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepo.ObterPorIdAsync(new UsuarioId(request.Id));

        if (usuario == null)
            throw new NotFoundException("Usuário não encontrado.");

        return new DetalhesUsuarioDto
        {
            Id = usuario.Id.Value,
            Nome = usuario.Nome,
            Email = usuario.Email,
            NomeUsuario = usuario.NomeUsuario,
            DataCadastro = usuario.DataCadastro,
            TipoAcesso = usuario.TipoAcesso
        };
    }
}
