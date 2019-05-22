using RabbitMQ.RabbitMQContext;
using Xunit;

namespace RabbitMQ.Tests
{
    public class Queue
    {
        private readonly RabbitMQService _obj = new RabbitMQService();

        [Fact]
        public void CreateQueue_Success()
        {
            // Arrange
            var factory = _obj.GetConnectionFactory();
            var connection = _obj.CreateConnection(factory);

            // Act
            var queue = _obj.CreateQueue("QueueName_UnitTest", connection);

            // Assert
            Assert.True(queue != null);

            connection.Close();
            connection.Dispose();
        }
    }
}