using Microsoft.AspNetCore.Mvc;
using RabbitMQ.RabbitMQContext;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        public readonly IRabbitMQService RabbitMQService;

        public QueueController(IRabbitMQService rabbitMQService)
        {
            RabbitMQService = rabbitMQService;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "OK";            
        }

    }
}
