//using Microsoft.Practices.Unity;
using RabbitMQ.RabbitMQContext;
using Unity;

namespace DI
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