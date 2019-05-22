using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.DI;
using RabbitMQ.RabbitMQContext;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;

namespace Rest.Controllers
{
    public class QueueController : ApiController
    {
        UnityContainer container = UnityConfig.GetMainContainer();
        IConnection connection = null;
        string queueName = ConfigurationManager.AppSettings["NewQueue"].ToString();

        public QueueController()
        {

        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public void Post(HttpRequestMessage  value)
        {
            var json = value.Content.ReadAsStringAsync().Result;            
            var obj = container.Resolve<IRabbitMQService>();            
            var connectionFactory = obj.GetConnectionFactory();
            connection = obj.CreateConnection(connectionFactory);
            obj.WriteMessageOnQueue(json, queueName, connection);
        }

    }
}
