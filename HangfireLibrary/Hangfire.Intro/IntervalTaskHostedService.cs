using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hangfire.Intro
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        // Cuando se inicia la tarea, definir qué tarea, hasta cuándo, cada cuanto 
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SaveFile, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public void SaveFile(object state)
        {
            string nameFile = "file" + new Random().Next(1000) + ".txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", nameFile);
            File.Create(path);
        }
        // Cuando se finaliza la tarea, reinicializar el objeto
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        
        // Eliminar este objeto
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
