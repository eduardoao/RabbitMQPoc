﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Client
{
    public partial class Service1 : ServiceBase
    {
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
            var aplicationlistmachine = AplicationServices.GetAllServices();
        }
    }
}
