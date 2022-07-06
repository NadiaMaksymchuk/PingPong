using RabbitMQ.Wrapper;


namespace Pinger
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                RabbitMQImplementation.ListenQueue(ConstantValues.PingQueue);
                Thread.Sleep(2500);
                RabbitMQImplementation.SendMessageToQueue(ConstantValues.PongQueue, "Ping");
            }
        }
    }
}
