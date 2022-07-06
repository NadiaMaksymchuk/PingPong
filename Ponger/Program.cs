using RabbitMQ.Wrapper;


namespace Ponger
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            { 
                RabbitMQImplementation.SendMessageToQueue(ConstantValues.PingQueue, "Pong");
                
                RabbitMQImplementation.ListenQueue(ConstantValues.PongQueue);
                Thread.Sleep(2500);
            }
        }
    }

}