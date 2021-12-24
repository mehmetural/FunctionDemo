using Azure.Data.Tables;
using FunctionsDemo.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DIConfig
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var tableClientConnectionString = configuration["AzureFunctionsJobHost:connectionStrings:tableStorage"];

        services.AddScoped(_ => new TableServiceClient(tableClientConnectionString));
        services.AddScoped(typeof(IRepository<>), typeof(TableClientRepository<>));

        return services;
    }
}
