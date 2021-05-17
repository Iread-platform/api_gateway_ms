using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;


namespace iread_api_gateway_ms
{
    public class Program
    {
    public static void Main(string[] args)
    {
        new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((context, config) => 
            {
                config
                    .SetBasePath(context.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            }).ConfigureServices(s => {
                s.AddOcelot().AddConsul();
            }).ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConsole();
            })
            .UseIIS()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
            })
            .Build().Run();
    }
}
}
