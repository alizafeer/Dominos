using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ClassLibrary;

namespace FunctionApp
{
        /*So the task was to create an Azure Serverless FunctionApp that takes an integer a as input and returns it with increment of 1.
        I was asked to use Http Triggers for that. I was also asked to add an Xunit project and write unit tests to test that Azure Function.
        You told me about DI and i tried to use that in this as well as this was a good opportunity to get it done. And as you mentioned, after
        spending time on these things, they arent that tough to get down :)*/
    public class AddFunction
    {
        //typical DI interface variable in target class
        private readonly IAdder _iAdder;
        public AddFunction(IAdder iAdder)
        {
            //DI injected
            _iAdder = iAdder;
        }

        //Our serverless function that will use DI to Add 1 to the input param in HttpRequest
        [FunctionName("AddUp")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Read the value of 'a' from the query parameters
            string aValue = req.Query["a"];
            int a;
            if (!int.TryParse(aValue, out a))
            {
                return new BadRequestObjectResult("Please pass a valid integer value for 'a' in the query string.");
            }

            //Using DI here for low cohesion and more testability
            int result = _iAdder.AddUp(a);

            return new OkObjectResult(result);
        }
    }
}
