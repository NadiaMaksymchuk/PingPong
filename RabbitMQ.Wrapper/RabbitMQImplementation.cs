using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Wrapper
{
    public static class RabbitMQImplementation
    {
        private static string exchangeName = "direct_logs";

        public static void ListenQueue(string routingKey)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueName = channel.QueueDeclare(queue: routingKey,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null).QueueName;
               
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine("'{0}':'{1}'",
                                      DateTime.Now, message);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }

        public static void SendMessageToQueue(string routingKey, string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var name = channel.QueueDeclare(queue: routingKey,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null).QueueName;

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
