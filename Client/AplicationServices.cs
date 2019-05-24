using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class AplicationServices
    {
        public static bool ProcessConsumer()
        {
            var listAllProcesses = GetAllProcesses();
            if (listAllProcesses.Count == 0) return false;
            SetAllServices(listAllProcesses); //Change this part
            return true;

        }

        private static List<AplicationDomain> GetAllProcesses()
        {
            var aplicationlistmachine = new List<AplicationDomain>();

            foreach (ServiceController service in ServiceController.GetServices())
            {
                var aplicationmachine = new AplicationDomain
                {
                    ServiceDisplayName = service.DisplayName,
                    ServiceName = service.DisplayName,
                    ServiceType = service.ServiceType,
                    Status = service.Status,
                    MachiName = Environment.MachineName,
                    DateTimeUtc = DateTime.UtcNow

                };
                aplicationlistmachine.Add(aplicationmachine);

            }
            return aplicationlistmachine;
        }

        private static async void SetAllServices(List<AplicationDomain> listservices)
        {
            var URI = ConfigurationManager.AppSettings["Uri"];
            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                var serializedProduto = JsonConvert.SerializeObject(listservices);
                var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                result = await client.PostAsync(URI, content);
            }
        }
    }

}
