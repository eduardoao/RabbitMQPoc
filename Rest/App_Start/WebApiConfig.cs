using RabbitMQ.Client;
using DI;
using RabbitMQ.RabbitMQContext;
using System.Configuration;
using System.Web.Http;
using Unity;

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
