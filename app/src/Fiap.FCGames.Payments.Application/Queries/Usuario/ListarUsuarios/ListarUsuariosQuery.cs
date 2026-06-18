using MediatR;

namespace Fiap.FCGames.Payments.Application.Queries.Usuario.ListarUsuarios;

public record ListarUsuariosQuery : IRequest<IEnumerable<ListaUsuariosDto>>;
