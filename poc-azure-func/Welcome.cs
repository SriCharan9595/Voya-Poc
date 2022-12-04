using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace poc_azure_func
{
    public static class Welcome
    {
        /*
         * @Description To get a response with http trigger
         **/
        [FunctionName("hello")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Welcome Started...");

            string name = req.Query["name"];

            string responseMessage = string.IsNullOrEmpty(name)
                ? "Http triggered successfully. But pass a name as query parameter for better response."
                : $"Hello, {name}. You're good to go...";

            return new OkObjectResult(responseMessage);
        }
    }
}
