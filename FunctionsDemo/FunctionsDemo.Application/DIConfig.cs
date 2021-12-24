using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class DIConfig
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
