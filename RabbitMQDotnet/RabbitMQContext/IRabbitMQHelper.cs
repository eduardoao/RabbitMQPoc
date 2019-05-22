using System.Collections.Generic;
using RabbitMQ.Client;

namespace RabbitMQ.RabbitMQContext
{
    public interface IRabbitMQService
    {
        //Create factory connection
        ConnectionFactory GetConnectionFactory();
        //Return a unique message from Rabbit
        string RetrieveSingleMessage(string queueName, IConnection connection);
        //Return amount message.
        uint RetrieveMessageCount(string queueName, IConnection connection);
        IConnection CreateConnection(ConnectionFactory connectionFactory);
        QueueDeclareOk CreateQueue(string queueName, IConnection connection);
        List<string> RetrieveMessageList(string queueName, IConnection connection);
        bool WriteMessageOnQueue(string message, string queueName, IConnection connection);
    }
}