using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using System;
using System.Threading.Tasks;
using SLBBackend.Services.ConfigurationServices;

namespace SLBBackend.Services.BlobServices
{
    public class BlobContainerService : IBlobContainerService
    {
        private readonly IConfigurationService _configurationService;

        public BlobContainerService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }


        public CloudBlobContainer GetBlobContainer(string reference)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configurationService.ImageStorageAccount);

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();

            var container = client.GetContainerReference(reference);

            container.CreateIfNotExists();

            return container;
        }

        public async Task<BlobResultSegment> GetBlobsAsync(CloudBlobContainer container)
        {
            return await container.ListBlobsSegmentedAsync(
                string.Empty,
                true,
                BlobListingDetails.All,
                Int32.MaxValue,
                null,
                new BlobRequestOptions(),
                new OperationContext());
        }
    }
}
