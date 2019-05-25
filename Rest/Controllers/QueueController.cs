using Newtonsoft.Json;
using RabbitMQ.Client;
using DI;
using RabbitMQ.RabbitMQContext;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using Unity;
using Domain.Interfaces;
using Service.Services;
using Domain.Entities;
using System.Web.Mvc;
using System;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using Service.Validators;

namespace Rest.Controllers
{
    public class QueueController : ApiController
    {
        private IService<AplicationDomain> service = new AplicationService<AplicationDomain>();


        UnityContainer container = UnityConfig.GetMainContainer();
        IConnection connection = null;
        readonly string queueName = ConfigurationManager.AppSettings["NewQueue"].ToString();

        IRabbitMQService obj;
        ConnectionFactory connectionFactory;

        public QueueController()
        {
            obj = container.Resolve<IRabbitMQService>();
            connectionFactory = obj.GetConnectionFactory();
            connection = obj.CreateConnection(connectionFactory);
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        public bool Get()
        {
            try
            {               
                var listAplication = obj.RetrieveSingleMessage(queueName, connection);
                
                //todo
                //Apenas caminho feliz ... Dando tempo altero.
                if (listAplication == null) return false;

                var aplicationDomain = JsonConvert.DeserializeObject<List<AplicationDomain>>(listAplication);
                foreach (var item in aplicationDomain)
                {
                    //todo
                    //Apenas caminho feliz ... Dando tempo altero.
                    service.Post<AplicationDomainValidator>(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return false;
            }
           

        }

        // POST api/values
        // Escreve na fila
        [HttpPost]
        public void Post(HttpRequestMessage  value)
        {
            try
            {
                var json = value.Content.ReadAsStringAsync().Result;               
                obj.WriteMessageOnQueue(json, queueName, connection);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex);
            }

        }




    }
}
