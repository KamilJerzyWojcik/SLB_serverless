using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading.Tasks;

namespace BlobAzureFunction.Services
{
    public static class BlobContainerService
    {
        public static CloudBlobContainer GetBlobContainer(ExecutionContext context, string reference)
        {
            var config = ConfigurationService.GetConfiguation(context);

            CloudStorageAccount storageAccount = CloudStorageAccount
            .Parse(config["ImageStorageAccount"]);

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();

            var container = client.GetContainerReference(reference);

            container.CreateIfNotExists();

            return container;
        }

        public static async Task<BlobResultSegment> GetBlobsAsync(CloudBlobContainer container)
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
