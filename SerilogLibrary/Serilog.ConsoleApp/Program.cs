using Serilog.Sinks.SystemConsole.Themes;

namespace Serilog.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                             .MinimumLevel.Verbose()
                             .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                             .CreateLogger();
        }
    }
}
