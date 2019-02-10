using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Vecc.LogCorrelation.Example.Source
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog((context, config) =>
                {
                    config.WriteTo.Debug(new JsonFormatter(renderMessage: true), LogEventLevel.Verbose);
                    config.MinimumLevel.Information();
                })
                .UseStartup<Startup>();
    }
}
