using System;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace poc_azure_func
{
    public class BlobReadWithQueue
    {
        /*
         * @Description To read files in blob storage with queue message
         **/
        [FunctionName("blobReadWithQueue")]
        public void Run(
            [QueueTrigger("out-queue", Connection = "AzureWebJobsStorage")] string myQueueItem,
            [Blob("blob-read/{queueTrigger}", System.IO.FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream inRead,
            ILogger log)
        {
            StreamReader readFile = new StreamReader(inRead);

            string responseMessage = $"\n File Name: {myQueueItem} \n File Size: {inRead.Length} bytes \n" +
                $" File Content: {readFile.ReadToEnd()}";

            log.LogInformation("Blob Read With Queue Started...");

            log.LogInformation($"{responseMessage}");
        }
    }
}
