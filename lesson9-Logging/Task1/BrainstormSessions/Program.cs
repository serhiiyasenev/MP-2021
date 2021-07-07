using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.config"));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddFilter("Microsoft", LogLevel.None);
                    builder.AddLog4Net();
                });
    }
}
