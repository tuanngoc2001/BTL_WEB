using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Web_API_v1;

namespace Web.API.v1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            Log.Information("Application Started");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.CloseAndFlush();
                Log.Error(e, "loi");
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                
                .WriteTo.File("log/Log.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                rollingInterval: RollingInterval.Day)
                .WriteTo.File("log/error.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)

                .CreateLogger();
        }
    }
}
