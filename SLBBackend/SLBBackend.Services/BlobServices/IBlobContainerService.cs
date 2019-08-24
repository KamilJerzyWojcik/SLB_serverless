using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace SLBBackend.Services.BlobServices
{
    public interface IBlobContainerService
    {
        CloudBlobContainer GetBlobContainer(string reference);

        Task<BlobResultSegment> GetBlobsAsync(CloudBlobContainer container);
    }
}
