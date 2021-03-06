using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Serilog.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configuración del objeto Log de Serilog
            Log.Logger = new LoggerConfiguration()
                            //.MinimumLevel.Verbose()
                            .MinimumLevel.Error()
                            .WriteTo.File(@"C:\Users\timea\source\repos\librerias-aspnet\SerilogLibrary\Serilog.Blazor\Logs\log.txt",
                                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message:lj}{NewLine}{Exception}")
                            .CreateLogger();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //Para que esté disponible Serilog en toda la aplicación
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
