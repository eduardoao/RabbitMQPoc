using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Data.Migrations
{ 

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.DataAccessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(Data.Context.DataAccessContext context)
        //{

        //    var aplicationDomains = new List<AplicationDomain>
        //    {
        //        new AplicationDomain{DateTimeUtc= DateTime.UtcNow, MachiName = "teste", ServiceDisplayName = "teste", ServiceName = "SN",
        //            ServiceType =  System.ServiceProcess.ServiceType.Adapter, Status = System.ServiceProcess.ServiceControllerStatus.ContinuePending },
        //        new AplicationDomain{DateTimeUtc= DateTime.UtcNow, MachiName = "teste", ServiceDisplayName = "teste", ServiceName= "SN1",
        //            ServiceType =  System.ServiceProcess.ServiceType.Adapter, Status = System.ServiceProcess.ServiceControllerStatus.ContinuePending },
        //    };
        //    aplicationDomains.ForEach(e => context.AplicationDomains.AddOrUpdate(p => p.ServiceName, e));
        //    context.SaveChanges();
        //}
    }
}
