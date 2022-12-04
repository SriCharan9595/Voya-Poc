using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace poc_azure_func
{
    public class BlobWriteWithQueue
    {
        /*
         * @Description To write file in blob storage with queue message
         **/
        [FunctionName("blobWriteWithQueue")]
        public void Run(
            [QueueTrigger("message", Connection = "AzureWebJobsStorage")] string myQueueItem,
            [Blob("blob-write/latestQueueMsg.txt", System.IO.FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outWrite,
            ILogger log)
        {
            log.LogInformation("Blob Write With Queue Started...");
            outWrite.Write(Encoding.ASCII.GetBytes(myQueueItem));

        }
    }
}
