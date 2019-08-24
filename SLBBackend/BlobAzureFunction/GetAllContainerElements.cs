using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BlobAzureFunction.Services;
using System;
using System.Linq;
using BlobAzureFunction.Extensions;

namespace BlobAzureFunction
{
    public static class GetAllContainerElements
    {
        [FunctionName("GetAllContainerElements")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log,
            ExecutionContext context)
        {
            var userId = UserService.GetCurrentId();

            var container = BlobContainerService.GetBlobContainer(context, userId);

            var blobs = await BlobContainerService.GetBlobsAsync(container);

            var paths = blobs.Results.Where(p => !p.Uri.AbsoluteUri.Contains("_thumbnail.")).Select(p => p.Uri.AbsoluteUri);

            var root = paths.GetHierarchy(userId);

            return new OkObjectResult(root);
        }
    }
}
