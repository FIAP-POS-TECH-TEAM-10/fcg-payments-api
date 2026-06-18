using MediatR;

namespace Fiap.FCGames.Payments.Application.Commands.Login;

public record LoginCommand(string Usuario, string Senha) : IRequest<UsuarioLogadoDto>;
