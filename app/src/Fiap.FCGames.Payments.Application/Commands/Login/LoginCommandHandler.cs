using Fiap.FCGames.Payments.Domain.Exception;
using Fiap.FCGames.Payments.Domain.Interface.Service;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using MediatR;

namespace Fiap.FCGames.Payments.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UsuarioLogadoDto>
{
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepository _usuarioRepo;

    public LoginCommandHandler(IUsuarioRepository usuarioRepo, ITokenService tokenService)
    {
        _usuarioRepo = usuarioRepo;
        _tokenService = tokenService;
    }

    public async Task<UsuarioLogadoDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        DateTime tokenExpiracao = DateTime.Now.AddMinutes(30);

        var usuario = await _usuarioRepo.ObterAsync(request.Usuario, request.Senha);

        if (usuario is null)
            throw new LoginException("Usuário ou senha inválidos", 401);

        string role = usuario.TipoAcessoUsuario.Role;

        var token = _tokenService.GerarToken(request.Usuario, role, tokenExpiracao);

        return new UsuarioLogadoDto
        {
            Token = token,
            Usuario = request.Usuario,
            LoginExpiracao = tokenExpiracao
        };
    }
}
