using Microsoft.Practices.Unity;
using RabbitMQ.RabbitMQContext;

namespace RabbitMQ.DI
{
    public static class UnityConfig
    {
        public static UnityContainer GetMainContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRabbitMQService, RabbitMQService>();

            return container;
        }
    }
}