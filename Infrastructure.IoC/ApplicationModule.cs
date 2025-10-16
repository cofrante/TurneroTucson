using Application.Services;
using Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IReservaService, ReservaService>();
        return services;
    }
}