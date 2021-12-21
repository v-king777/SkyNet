using Microsoft.Extensions.DependencyInjection;
using SkyNet.Data.Repository;
using SkyNet.Data.UoW;

namespace SkyNet.Extentions;

public static class ServiceExtentions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddCustomRepository<TEntity, IRepository>(this IServiceCollection services)
        where TEntity : class
        where IRepository : class, IRepository<TEntity>
    {
        services.AddScoped<IRepository<TEntity>, IRepository>();

        return services;
    }
}