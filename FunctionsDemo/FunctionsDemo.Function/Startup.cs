using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionsDemo.Function.Startup))]

namespace FunctionsDemo.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var serviceCollection = builder.Services;
            var configuration = builder.GetContext().Configuration;

            serviceCollection
                .AddInfrastructure(configuration)
                .AddApplication();
        }
    }
}
