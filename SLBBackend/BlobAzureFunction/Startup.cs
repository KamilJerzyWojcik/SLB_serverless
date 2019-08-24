using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SLBBackend.Services.BlobServices;
using SLBBackend.Services.ConfigurationServices;
using SLBBackend.Services.UserServices;

[assembly: FunctionsStartup(typeof(BlobAzureFunction.Startup))]

namespace BlobAzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IBlobContainerService, BlobContainerService>();
            builder.Services.AddSingleton<IApplicationSettingsService, ApplicationSettingsService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddSingleton<IAzureClientsService, AzureClientsService>();
        }
    }
}
