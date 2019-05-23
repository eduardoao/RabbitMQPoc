using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AplicationDomain: Base
    {
        public string ServiceName { get; set; }
        public string ServiceDisplayName { get; set; }
        public ServiceType ServiceType { get; set; }
        public ServiceControllerStatus Status { get; set; }
        public string MachiName { get; set; }
        public DateTime DateTimeUtc { get; set; }

    }
}
