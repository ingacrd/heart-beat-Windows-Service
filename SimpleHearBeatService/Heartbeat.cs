﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHearBeatService
{
    public class Heartbeat
    {
        private readonly Timer _timer;

        public Heartbeat()
        {
            _timer = new Timer(1000) { AutoReset = true};
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\carolina.ruiz\Documents\Temp\Heartbeat.txt", lines);
            
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop() { _timer.Stop(); }
    }
}
