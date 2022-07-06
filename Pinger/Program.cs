using RabbitMQ.Wrapper;


namespace Pinger
{
    public class Program
    {
        static void Main()
        {
            while(true)
            {
                
                RabbitMQImplementation.ListenQueue(ConstantValues.PingQueue);
                Thread.Sleep(5000);
                RabbitMQImplementation.SendMessageToQueue(ConstantValues.PongQueue, "Ping");
                Thread.Sleep(5000);
            }
        }
    }
}
