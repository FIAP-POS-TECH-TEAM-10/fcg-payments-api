using Fiap.FCGames.Payments.Infra.DataProvider.Interface;
using Fiap.FCGames.Payments.Infra.DataProvider.Repositories;
using Fiap.FCGames.Payments.Infra.DataProvider.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.FCGames.Payments.CrossCutting.Extensions;

public static class RegisterDependencyInjectionExtensions
{
    public static void RegisterDI(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();
    }
}
