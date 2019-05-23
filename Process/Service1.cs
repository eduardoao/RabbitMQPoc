using DI;
using RabbitMQ.Client;
using RabbitMQ.RabbitMQContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Unity;

namespace Process
{
    public partial class Service1 : ServiceBase
    {

        UnityContainer container = UnityConfig.GetMainContainer();
        IConnection connection = null;
        string queueName = ConfigurationManager.AppSettings["NewQueue"].ToString();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Set up a timer that triggers 01 minute.
            var timer = new System.Timers.Timer();
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(this.OnGetService);
            timer.Start();

        }

        protected override void OnStop()
        {
        }

        void OnGetService(object sender, ElapsedEventArgs args)
        {
            // Creating IOC Container
            container = UnityConfig.GetMainContainer();
            var obj = container.Resolve<IRabbitMQService>();


            // Creating Connection and Connection Factory
            var connectionFactory = obj.GetConnectionFactory();
            connection = obj.CreateConnection(connectionFactory);

            // Retrieving One Message           
            var message = obj.RetrieveSingleMessage(queueName, connection);
           



        }
    }
}
