using System.Reflection;

namespace MovieApi.WebApi.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("MovieApi.Application")));
        return services;
    }
}