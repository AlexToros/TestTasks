using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Config;
using Task_1.Watcher;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurator configurator = new MainConfigurator();
            IWatcher watcher = configurator.GetWatcher();

            watcher.Start();

            Console.WriteLine("FileWatcher started.");
            Console.WriteLine("Press 'q' to end.");
            while (Console.Read() != 'q') ;
        }
    }
}
