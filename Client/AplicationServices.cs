using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class AplicationServices
    {
        public static List<AplicationDomain> GetAllServices()
        {
            var aplicationlistmachine = new List<AplicationDomain>();

            foreach (ServiceController service in ServiceController.GetServices())
            {
                var aplicationmachine = new AplicationDomain
                {
                    serviceDisplayName = service.DisplayName,
                    serviceName = service.DisplayName,
                    //ServiceType = service.ServiceType,
                    //Status = service.Status,
                    MachiName = Environment.MachineName,
                    DateTimeUtc = DateTime.UtcNow

                };
                aplicationlistmachine.Add(aplicationmachine);

            }
            return aplicationlistmachine;
        }
    }

}
