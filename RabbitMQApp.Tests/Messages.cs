using RabbitMQ.Client;
using RabbitMQ.RabbitMQContext;
using System;
using Xunit;

namespace RabbitMQ.Tests
{
    public class Messages
    {
        private readonly RabbitMQService _obj = new RabbitMQService();

        [Fact]
        public void CreateMessage_Success()
        {
            // Arrange
            var factory = _obj.GetConnectionFactory();
            var connection = _obj.CreateConnection(factory);
            var queue = _obj.CreateQueue("QueueName_Message_UnitTest", connection);

            // Act
            var ret = _obj.WriteMessageOnQueue("Message to Write", queue.QueueName, connection);

            // Assert
            Assert.True(ret);

            connection.Close();
            connection.Dispose();
        }

        [Fact]
        public void RetrieveMessage_Success()
        {
            // Arrange
            Random rnd = new Random();
            var factory = _obj.GetConnectionFactory();
            var connection = _obj.CreateConnection(factory);
            var queue = _obj.CreateQueue("QueueName_Message_UnitTest", connection);
            _obj.WriteMessageOnQueue(string.Format("Message to Write - {0}", rnd), queue.QueueName, connection);

            // Act
            var ret = _obj.RetrieveSingleMessage("QueueName_Message_UnitTest", connection);

            // Assert
            Assert.True(ret != null);

            connection.Close();
            connection.Dispose();
        }

        [Fact]
        public void RetrieveMesssageList_Succcess()
        {
            // Arrange
            var factory = _obj.GetConnectionFactory();
            var connection = _obj.CreateConnection(factory);
            var queue = _obj.CreateQueue("QueueName_Message_UnitTest", connection);
            _obj.WriteMessageOnQueue("Message to Write", queue.QueueName, connection);

            // Act
            var ret = _obj.RetrieveMessageList("QueueName_Message_UnitTest", connection);

            // Assert
            Assert.True(ret != null);

            connection.Close();
            connection.Dispose();
        }
    }
}