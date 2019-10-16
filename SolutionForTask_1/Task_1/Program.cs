using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSystemWatcher fsw = new FileSystemWatcher(ConfigurationManager.AppSettings["ObservableDirectory"]);
            fsw.Created += Fsw_Created;
        }

        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);

        }
    }
}
