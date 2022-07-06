using RabbitMQ.Wrapper;


namespace Ponger
{
    internal class Program
    {
        static void Main()
        {
            while(true)
            {
                RabbitMQImplementation.SendMessageToQueue(ConstantValues.PingQueue, "Pong");
                Thread.Sleep(5000);
                RabbitMQImplementation.ListenQueue(ConstantValues.PongQueue);
                Thread.Sleep(5000);
            }
        }
    }
}