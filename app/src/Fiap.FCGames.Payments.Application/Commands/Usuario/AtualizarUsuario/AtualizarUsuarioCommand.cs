using MediatR;

namespace Fiap.FCGames.Payments.Application.Commands.Usuario.AtualizarUsuario;

public record AtualizarUsuarioCommand(
    Guid Id,
    string Nome,
    string Email,
    string Senha,
    string NomeUsuario) : IRequest<AtualizarUsuarioResponse>;
