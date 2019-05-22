using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesteService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Service Client 
            List<AplicationDomain> aplicationServices = Client.AplicationServices.GetAllServices();
            string json = JsonConvert.SerializeObject(aplicationServices);

        }
    }
}
