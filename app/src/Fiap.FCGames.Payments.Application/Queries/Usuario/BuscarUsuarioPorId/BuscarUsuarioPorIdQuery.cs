using MediatR;

namespace Fiap.FCGames.Payments.Application.Queries.Usuario.BuscarUsuarioPorId;

public record BuscarUsuarioPorIdQuery(Guid Id) : IRequest<DetalhesUsuarioDto>;
