using MediatR;

namespace Fiap.FCGames.Payments.Application.Commands.Usuario.CriarUsuario;

public record CriarUsuarioCommand(
    string Nome,
    string Email,
    string NomeUsuario,
    string Senha) : IRequest<CriarUsuarioResponse>;
