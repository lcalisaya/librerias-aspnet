using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace Serilog.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                             .MinimumLevel.Verbose()//Mostrará todos los niveles de logueo
                             .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                             .CreateLogger();

            try
            {
                Log.Debug("Debugging my app with Serilog...");
                Log.Information("Hello {Name}!", Environment.GetEnvironmentVariable("USERNAME"));
                Log.Warning("It was expected to match another result here");

                ThrowAnError();
            }
            catch (Exception e) {
                Log.Error(e.Message);
                Log.Error(e, "An error occurred!");
            }

            Log.CloseAndFlush();
        }

        static void ThrowAnError()
        {
            throw new NullReferenceException();
        }
    }
}
