﻿using System.ServiceProcess;
using System.Timers;

namespace Client
{
    public partial class ServiceCliente : ServiceBase
    {
        public ServiceCliente()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            System.Diagnostics.Debugger.Launch();
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
            _ = AplicationServices.ClientConsumer();
        }
    }
}
