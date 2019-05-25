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
            LambdaTest();


            Repository<AplicationDomain> repository = new Repository<AplicationDomain>();
           

           

            //Call Service Client 
            var aplicationServices = Client.AplicationServices.ClientConsumer();
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
                for (int i = 0; i < 100; i++)
                {
                    var newmessage = $"New Message Generated on: {DateTime.Now:dd/MM/yyyy HH:mm:ss:fff}";
                    //var aplication = new AplicationDomain { DateTimeUtc = DateTime.UtcNow, MachiName = "Teste0", Id = 1, ServiceDisplayName = "tes", ServiceName = "tests", ServiceType = System.ServiceProcess.ServiceType.Adapter, Status = 0 };


                    obj.WriteMessageOnQueue(newmessage, queueName, connection);
                    Console.WriteLine($"Message Successfully Written: {newmessage}");
                }
                Console.WriteLine(" ");

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


        private static void LambdaTest()
        {
//1   Servi? o de Roteador AllJoyn Servi?o de Roteador AllJoyn 32  1   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//2   Servi? o Gateway de Camada de Aplicativo Servi?o Gateway de Camada de Aplicativo 16  1   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//3   Servi? o Auxiliar de Host do Aplicativo Servi?o Auxiliar de Host do Aplicativo  48  4   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//4   Identidade do Aplicativo Identidade do Aplicativo    32  1   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//5   Informa ?? es sobre Aplicativos   Informa ?? es sobre Aplicativos   48  4   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//6   Gerenciamento de aplicativo Gerenciamento de aplicativo 32  1   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09
//7   Prepara ?? o de Aplicativos   Prepara ?? o de Aplicativos   48  1   LAPTOP - 45V304UA 22 / 05 / 2019 23:58:09

            Repository<AplicationDomain> repository = new Repository<AplicationDomain>();

            var aplication1 = new AplicationDomain {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste0",                
                ServiceDisplayName = "tes",
                ServiceName = "Identidade do Aplicativo Identidade do Aplicativo",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            

            var aplication2 = new AplicationDomain
            {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste0",
                Id = 1,
                ServiceDisplayName = "tes",
                ServiceName = "Gerenciamento de aplicativo Gerenciamento de aplicativo",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            var aplication3 = new AplicationDomain
            {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste0",
                Id = 1,
                ServiceDisplayName = "tes",
                ServiceName = "tests",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            var aplication4 = new AplicationDomain
            {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste1",
                Id = 1,
                ServiceDisplayName = "tes",
                ServiceName = "Identidade do Aplicativo Identidade do Aplicativo",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            var aplication5 = new AplicationDomain
            {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste1",
                Id = 1,
                ServiceDisplayName = "tes",
                ServiceName = "tests",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            var aplication6 = new AplicationDomain
            {
                DateTimeUtc = DateTime.UtcNow,
                MachiName = "Teste2",
                Id = 1,
                ServiceDisplayName = "tes",
                ServiceName = "Identidade do Aplicativo Identidade do Aplicativo",
                ServiceType = System.ServiceProcess.ServiceType.Adapter,
                Status = 0
            };

            repository.Insert(aplication1);
            repository.Insert(aplication2);
            repository.Insert(aplication3);
            repository.Insert(aplication4);
            repository.Insert(aplication5);
            repository.Insert(aplication6);


            var ret = repository.SelectAll();


            var lambdaBreedsCount = ret.GroupBy(x => x.ServiceName).Select(grp =>
                          new {
                              Breed = grp.Key,
                              Count = grp.Count()
                          }).ToList().OrderBy( e => e.Count);


           
            var dta = DateTime.UtcNow.AddMinutes(-30);

            var dta1 = DateTime.UtcNow.AddMinutes(-30 * 1.5);

            var resultado = repository.Query(a => (a.DateTimeUtc) <= dta)
                            .Select(i => new { Machine = i.MachiName })
                            .ToList().GroupBy(grp => grp.Machine).Distinct();

            //var resultado = repository.Query(a => DbFunctions.TruncateTime(a.DataCadastro) == dta)
            //              .Select(i => new { i.MachiName })
            //              .ToList();


        }


    }
}
