using FunctionsDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FunctionsDemo.Function
{
    public class SomeDataFunction
    {
        private readonly ISender sender;

        public SomeDataFunction(ISender sender)
        {
            this.sender = sender;
        }

        [FunctionName("SomeDataFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var result = await sender.Send(new SaveSomeDataCommand { Data = new Domain.Models.SomeData() { Data = "name" } });

            return new OkObjectResult(result);
        }
    }
}
