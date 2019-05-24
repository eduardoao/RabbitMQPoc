using Data.Repostitory;
using DI;
using Domain.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.RabbitMQContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleTesteService
{
    class Program
    {
        public static object ConfigurationManager { get; private set; }

        static void Main(string[] args)
        {
            var aplication = new AplicationDomain { DateTimeUtc = DateTime.UtcNow, MachiName = "Teste0", Id = 1, ServiceDisplayName = "tes", ServiceName = "tests", ServiceType = System.ServiceProcess.ServiceType.Adapter , Status = 0 };

            Repository<AplicationDomain> repository = new Repository<AplicationDomain>();
            repository.Insert(aplication);

           

            //Call Service Client 
            var aplicationServices = Client.AplicationServices.ProcessConsumer();
            string json = JsonConvert.SerializeObject(aplicationServices);

            IConnection connection = null;
            //var queueName = Guid.NewGuid().ToString();
            string queueName = "itSingularQueue";

            try
            {
                // Creating IOC Container
                var container = UnityConfig.GetMainContainer();
                var obj = container.Resolve<IRabbitMQService>();

                // Creating Connection and Connection Factory
                var connectionFactory = obj.GetConnectionFactory();
                connection = obj.CreateConnection(connectionFactory);

                // Creating a New Queue
                Console.WriteLine("Creating New Queue");
                obj.CreateQueue(queueName, connection);
                Console.WriteLine($"Queue Sucessfully Created: {queueName}");
                Console.WriteLine(" ");

                // Retrieving Message Count from Queue
                Console.Write("Messages Count: ");
                var messageCount = obj.RetrieveMessageCount(queueName, connection);
                Console.WriteLine(messageCount.ToString());
                Console.WriteLine(" ");

                //// Writing Messages to a Queue
                //for (int i = 0; i < 100; i++)
                //{
                //    var newmessage = $"New Message Generated on: {DateTime.Now:dd/MM/yyyy HH:mm:ss:fff}";

                //    obj.WriteMessageOnQueue(newmessage, queueName, connection);
                //    Console.WriteLine($"Message Successfully Written: {newmessage}");
                //}
                //Console.WriteLine(" ");

                // Retrieving One Message
                Console.Write("Retrieving One Message, Message Text: ");
                var message = obj.RetrieveSingleMessage(queueName, connection);

                //Test convert json to object
                var deserializedobject= JsonConvert.DeserializeObject<List<AplicationDomain>>(message);

                Console.WriteLine(message);
                Console.WriteLine(" ");

                // Retrieving Multiple Messages
                var lstMessages = obj.RetrieveMessageList(queueName, connection);
                foreach (var m in lstMessages)
                {
                    Console.WriteLine($"Message Text: {m} ");
                }
                Console.WriteLine(" ");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }


    }
}
