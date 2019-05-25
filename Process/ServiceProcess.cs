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
    public partial class ServiceProcess : ServiceBase
    {
        public ServiceProcess()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            Debugger.Launch();
#endif

            // Set up a timer that triggers 01 minute.
            var timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(this.OnGetService);
            timer.Start();

        }

        protected override void OnStop()
        {
        }

        void OnGetService(object sender, ElapsedEventArgs args)
        {
            AplicationServices.ProcessConsumer();
        }
    }
}
