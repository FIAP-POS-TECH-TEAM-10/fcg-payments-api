using Fiap.FCGames.Payments.Domain.Aggregates;
using Fiap.FCGames.Payments.Domain.Interface.Service;
using FluentValidation;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using MediatR;

namespace Fiap.FCGames.Payments.Application.Commands.Usuario.CriarUsuario;

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, CriarUsuarioResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasherService _passwordHasherService;

    public CriarUsuarioCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasherService passwordHasherService)
    {
        _unitOfWork = unitOfWork;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<CriarUsuarioResponse> Handle(
        CriarUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        var emailExiste = await _unitOfWork.UsuarioRepository.ExisteEmailAsync(request.Email);
        if (emailExiste)
            throw new ValidationException("Já existe um usuário com o e-mail informado.");

        var nomeUsuarioExiste = await _unitOfWork.UsuarioRepository.ExisteNomeUsuarioAsync(request.NomeUsuario);
        if (nomeUsuarioExiste)
            throw new ValidationException("Já existe um usuário com o nome de usuário informado.");

        var usuario = new Fiap.FCGames.Payments.Domain.Aggregates.Usuario
        {
            Id = UsuarioId.New(),
            Nome = request.Nome,
            Email = request.Email,
            NomeUsuario = request.NomeUsuario.ToLower(),
            Senha = _passwordHasherService.GerarHash(request.Senha),
            DataCadastro = DateTime.Now,
            TipoAcesso = TipoAcesso.User
        };
        _unitOfWork.UsuarioRepository.Adicionar(usuario);

        var biblioteca = new Fiap.FCGames.Payments.Domain.Aggregates.BibliotecaJogos
        {
            Id = BibliotecaJogosId.New(),
            IdUsuario = usuario.Id,
            DataCriacao = DateTime.Now
        };
        _unitOfWork.BibliotecaJogosRepository.Adicionar(biblioteca);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new CriarUsuarioResponse
        {
            Id = usuario.Id.Value,
            Nome = usuario.Nome,
            Email = usuario.Email,
            BibliotecaId = biblioteca.Id.Value
        };
    }
}
