using Microsoft.Practices.Unity;
using RabbitMQ.Client;
using RabbitMQ.DI;
using RabbitMQ.RabbitMQContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace Rest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            CreateQueueAplicationSession();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void CreateQueueAplicationSession()
        {
            UnityContainer container = UnityConfig.GetMainContainer();
            IConnection connection = null;
            string queueName = ConfigurationManager.AppSettings["NewQueue"].ToString();

            var obj = container.Resolve<IRabbitMQService>();
            var connectionFactory = obj.GetConnectionFactory();

            connection = obj.CreateConnection(connectionFactory);
            obj.CreateQueue(queueName, connection);
        }

    }
}
