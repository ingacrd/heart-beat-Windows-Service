using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHearBeatService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => 
            { 
                x.Service<Heartbeat>(s => 
                {
                    s.ConstructUsing(heartbeat => new Heartbeat());
                    s.WhenStarted(hearbeat => hearbeat.Start());
                    s.WhenStopped(hearbeat => hearbeat.Stop());
                    s.WhenStopped(hearbeat => hearbeat.Stop());

                });

                x.RunAsLocalSystem();
                x.SetServiceName("HeartbetService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("This is the sample heartbeat service used in a demo, just learning Windows Services");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
