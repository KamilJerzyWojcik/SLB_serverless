using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using System;
using System.Threading.Tasks;
using SLBBackend.Services.ConfigurationServices;

namespace SLBBackend.Services.BlobServices
{
    public class BlobContainerService : IBlobContainerService
    {
        private readonly IAzureClientsService _azureClientsService;

        public BlobContainerService(IAzureClientsService azureClientsService)
        {
            _azureClientsService = azureClientsService;
        }


        public CloudBlobContainer GetBlobContainer(string reference)
        {
            var container = _azureClientsService.CloudBlobClient.GetContainerReference(reference);

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
