using MediatR;

namespace Fiap.FCGames.Payments.Application.Queries.BibliotecaJogos.BuscarBibliotecaJogos;

public record BuscarBibliotecaJogosQuery(Guid UsuarioId) : IRequest<BuscarBibliotecaJogosResponse?>;
