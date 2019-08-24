using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace SLBBackend.Services.ConfigurationServices
{
    public class AzureClientsService : IAzureClientsService
    {
        private readonly CloudStorageAccount _cloudStorageAccount;

        public AzureClientsService(IApplicationSettingsService applicationSettingsService)
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(applicationSettingsService.ImageStorageAccount);
        }

        public CloudBlobClient CloudBlobClient => _cloudStorageAccount.CreateCloudBlobClient();

    }
}
