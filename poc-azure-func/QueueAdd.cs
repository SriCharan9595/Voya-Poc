using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.Storage;

namespace poc_azure_func
{
    public static class QueueAdd
    {
        /*
         * @Description To add a message in the queue storage
         **/
        [FunctionName("queueAdd")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Queue("out-queue"), StorageAccount("AzureWebJobsStorage")] ICollector<string> msg,
            ILogger log)
        {
            log.LogInformation("Queue Add Started...");

            string fileName = req.Query["file"];
            string responseMessage = "";

            if (!string.IsNullOrEmpty(fileName))
            {
                responseMessage = $"You Entered: {fileName} \nFile Entry Is Recorded...";
                msg.Add($"{fileName}");
            }
            else
            {
                responseMessage = "Try with your file name before testing next time...";
            }

            return new OkObjectResult(responseMessage);
        }
    }
}