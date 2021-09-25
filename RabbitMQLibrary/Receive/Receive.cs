using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos la conexión
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            {
                //Creamos el canal
                using(var channel = connection.CreateModel())
                {
                    //Declaramos un Exchange que se encargará de definir las queues
                    channel.ExchangeDeclare(exchange:"miExchange", type:ExchangeType.Fanout);

                    //Creamos una queue sin nombre
                    var queueName = channel.QueueDeclare().QueueName;

                    //Uno el exchange con la cola declarada
                    channel.QueueBind(queue: queueName, exchange: "miExchange", routingKey: "");
                    Console.WriteLine("Waiting for log messages...");

                    // channel.QueueDeclare(queue: "hello",
                    //                     durable: false,
                    //                     exclusive: false,
                    //                     autoDelete: false,
                    //                     arguments: null);

                    //La comunicación es asincrona entonces necesitamos un evento y un callback
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    //Se informa al servidor que el mensaje ha sido recibido
                    channel.BasicConsume(queue: queueName,
                                        autoAck: true,
                                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
