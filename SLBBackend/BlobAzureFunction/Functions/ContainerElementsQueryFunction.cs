using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using SLBBackend.Services.UserServices;
using SLBBackend.Services.BlobServices;
using SLBBackend.Services.Extensions;

namespace BlobAzureFunction
{
    public class ContainerElementsQueryFunction
    {
        private readonly IBlobContainerService _blobContainerService;
        private readonly IUserAccountService _userAccountService;

        public ContainerElementsQueryFunction(IBlobContainerService blobContainerService, IUserAccountService userAccountService)
        {
            _blobContainerService = blobContainerService;
            _userAccountService = userAccountService;
        }


        [FunctionName("GetAllContainerElements")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var userId = _userAccountService.GetCurrentId();

            var container = _blobContainerService.GetBlobContainer(userId);

            var blobs = await _blobContainerService.GetBlobsAsync(container);

            var paths = blobs.Results.Where(b => !b.Uri.AbsoluteUri.Contains("_thumbnail.")).Select(p => p.Uri.AbsoluteUri);

            var root = paths.GetHierarchy(userId);

            return new OkObjectResult(root);
        }
    }
}
