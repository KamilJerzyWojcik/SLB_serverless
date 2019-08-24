using System;

namespace SLBBackend.Services.ConfigurationServices
{
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public string ImageStorageAccount => Environment.GetEnvironmentVariable("ImageStorageAccount");
    }
}
