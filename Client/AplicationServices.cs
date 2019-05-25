using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Client
{
    public static class AplicationServices
    {
        public static bool ClientConsumer()
        {
            var listAllProcesses = GetAllProcesses();
            if (listAllProcesses.Count == 0) return false;           
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
      
    }

}
