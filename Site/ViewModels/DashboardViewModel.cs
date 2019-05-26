using Domain.Entities;
using System.Collections.Generic;

namespace Site.ViewModels
{
    public class DashboardViewModel
    {
        public int Timee { get; set; }
    }

    public class ReturnDashboardViewModel
    {
        public ReturnDashboardViewModel()
        {
            ReturnStatusMachine = new List<MachineAmount>();
            AplicationName = new List<string>();
            MachineOnlineName = new List<string>();

        }

        public List<MachineAmount> ReturnStatusMachine { get; set; }

        public List<string> AplicationName { get; set; }

        public List<string> MachineOnlineName { get; set; }

    }

    public enum Status
    {
        Online = 1,
        Offline = 2,
        Alerta = 3
    }

    public class MachineAmount
    {
        public int Amount { get; set; }     
        public Status Status { get; set; }
    }
}