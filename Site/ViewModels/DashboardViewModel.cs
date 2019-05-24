using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.ViewModels
{
    public class DashboardViewModel
    {
        public int Tempo { get; set; }      
    }

    public class ReturnDashboardViewModel
    {
        public AplicationDomain AplicationDomain { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Online = 1,
        Offline = 2,
        Alerta = 3
    }

}