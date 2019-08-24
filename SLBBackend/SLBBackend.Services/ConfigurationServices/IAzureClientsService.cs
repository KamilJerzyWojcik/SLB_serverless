using Microsoft.Azure.Storage.Blob;

namespace SLBBackend.Services.ConfigurationServices
{
    public interface IAzureClientsService
    {
        CloudBlobClient CloudBlobClient { get; }
    }
}
