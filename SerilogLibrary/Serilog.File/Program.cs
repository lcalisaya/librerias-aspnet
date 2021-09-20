using System;

namespace Serilog.File
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Se configura y siempre se utiliza la clase estática Log
            Log.Logger = new LoggerConfiguration()
                             .MinimumLevel.Verbose()
                             .WriteTo.File(@"C:\Users\lcalisaya\source\repos\librerias-aspnet\SerilogLibrary\Serilog.File\Logs\log.txt")
                             .CreateLogger();

            try
            {
                Log.Debug("Debugging my app with Serilog...");
                Log.Information("Hello {Name}!", Environment.GetEnvironmentVariable("USERNAME"));
                Log.Warning("It was expected to match another result here");

                ThrowAnError();
            }
            catch (Exception e)
            {
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
