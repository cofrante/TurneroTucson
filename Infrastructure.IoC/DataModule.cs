using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DataModule
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, string dbName = "TucsonDb")
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(dbName));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        FakeData.Load(context);

        return services;
    }
}
