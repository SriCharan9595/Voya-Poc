using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace poc_azure_func
{
    public class BlobRead
    {
        /*
         * @Description To read the file name, size, path and content while trigger in blob storage
         **/
        [FunctionName("blobRead")]
        public void Run(
            [BlobTrigger("blob-read/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, string blobTrigger,
            ILogger log)
        {
            StreamReader readFile = new StreamReader(myBlob);

            string responseMessage = $"\n File Name: {name} \n File Size: {myBlob.Length} bytes \n" +
                $" File Path: {blobTrigger} \n File Content: {readFile.ReadToEnd()}";

            log.LogInformation("Blob Read Started...");

            log.LogInformation($"{responseMessage}");
        }

    }
}
