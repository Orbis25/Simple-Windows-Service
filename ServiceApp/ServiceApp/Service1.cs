using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceApp
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private int i = 0;
        public Service1(string[] args)
        {
            InitializeComponent();
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            _timer = new Timer
            {
                Interval = 10000
            };
            _timer.Elapsed += new ElapsedEventHandler(Proceso);
            _timer.Enabled = true;
            _timer.Start();
        }

        private void Proceso(object sender, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            string path = @"C:\Users\Orbis\Desktop\file.txt";
            i++;
                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine($"Hello #{i}");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            _timer.Enabled = true;

        }

        protected override void OnStop()
        {
            EventLog.WriteEntry($"Proceso cerrado");
        }
    }
}
