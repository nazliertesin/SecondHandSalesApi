using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SecondhandSalesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read Configuration from appSettings
            var config = new ConfigurationBuilder()

                .AddJsonFile("appsettings.json")
                .Build();


            // Initialize Logger
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
            Log.Information("Application is starting.");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseSerilog() // add seri log 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
