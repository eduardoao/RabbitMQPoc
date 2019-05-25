using Domain.Entities;
using Domain.Interfaces;
using RabbitMQ.RabbitMQContext;
using Service.Services;
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