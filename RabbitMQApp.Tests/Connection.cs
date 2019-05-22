﻿using RabbitMQ.Client;
using RabbitMQ.RabbitMQContext;
using Xunit;

namespace RabbitMQ.Tests
{
    public class Connection
    {
        private readonly RabbitMQService _obj = new RabbitMQService();

        [Fact]
        public void GetConnectionFactory_Success()
        {
            // Arrange
            ConnectionFactory factory;

            // Act
            factory = _obj.GetConnectionFactory();

            // Assert
            Assert.True(factory != null);
        }

        [Fact]
        public void CreateConnection_Success()
        {
            // Arrange
            IConnection connection;
            var factory = _obj.GetConnectionFactory();

            // Act
            connection = _obj.CreateConnection(factory);

            // Assert
            Assert.True(connection != null);

            connection.Close();
            connection.Dispose();
        }
    }
}