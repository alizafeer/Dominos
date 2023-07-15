using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        /*Since you asked me to look into Dependency Injection in .Net core (I knew about .Net Framework which is different) I decided to look into
        it and use it in this assignment together with the other tasks.
        To summarize my understanding of how I used DI in this scenario is that I created a startup class which inherits from FunctionsStartup 
        and it handles the registration of the dependencies listed below using AddSingleton or AddScoped method that you mentioned and the Azure Functions
        runtime will use the DI container to resolve and inject the appropriate dependencies when creating instances of our functions */
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Register your dependencies here
            builder.Services.AddSingleton<IAdder, Adder>();
        }
    }
}
