using Fiap.FCGames.Payments.Domain.Interface.Service;
using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using Fiap.FCGames.Payments.Infra.DataProvider.Repositories;
using Fiap.FCGames.Payments.Infra.DataProvider.UnitOfWork;
using Fiap.FCGames.Payments.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.FCGames.Payments.CrossCutting.Extensions;

public static class RegisterDependencyInjectionExtensions
{
    public static void RegisterDI(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IBibliotecaJogosRepository, BibliotecaJogosRepository>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Services
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
    }
}
