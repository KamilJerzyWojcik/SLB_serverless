using System;

namespace SLBBackend.Services.ConfigurationServices
{
    public class ConfigurationService : IConfigurationService
    {

        public string ImageStorageAccount => Environment.GetEnvironmentVariable("ImageStorageAccount");
    }
}
