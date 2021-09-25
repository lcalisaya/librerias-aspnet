using System;
using RabbitMQ.Client;
using System.Text;
namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos una conexión
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            {
                //Creamos un canal
                using(var channel = connection.CreateModel())
                {
                    //Declaramos un Exchange que se encargará de definir las queues
                    channel.ExchangeDeclare(exchange:"miExchange", type:ExchangeType.Fanout);

                    //Creamos una cola
                    // channel.QueueDeclare(queue: "hello",
                    //                     durable: false,
                    //                     exclusive: false,
                    //                     autoDelete: false,
                    //                     arguments: null);

                    //Se crea el mensaje que se enviará y se lo transforma en un array de bytes
                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    //Se envía el mensaje
                    channel.BasicPublish(exchange: "miExchange",
                                        routingKey: "",
                                        basicProperties: null,
                                        body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string GetMessage(string [] args)
        {
            string ejemploString = args.Length > 0 ? string.Join(" ", args) : "Info: Hola mundo!";
            return ejemploString;
        }
    }
}
