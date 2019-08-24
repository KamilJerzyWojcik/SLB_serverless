using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;

namespace BlobAzureFunction.Services
{
    public static class ConfigurationService
    {
        public static IConfigurationRoot GetConfiguation(ExecutionContext context)
        {
            return new ConfigurationBuilder()
             .SetBasePath(context.FunctionAppDirectory)
             .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();
        }
    }
}
