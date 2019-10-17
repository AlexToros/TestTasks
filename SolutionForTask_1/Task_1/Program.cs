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
            IWatcher watcher = null;
            try
            {
                IConfigurator configurator = new MainConfigurator();
                watcher = configurator.GetWatcher();

                watcher.Start();

                Console.WriteLine("FileWatcher started.");
                Console.WriteLine("Press 'q' to end.");
                while (Console.ReadKey().KeyChar != 'q') ;
            }
            catch (ArgumentException ex)
            {
                ExceptionHandle(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                ExceptionHandle(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                ExceptionHandle(ex);
            }
            finally
            {
                watcher?.Dispose();
            }
        }
        private static void ExceptionHandle(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press 'q' to end.");
            while (Console.ReadKey().KeyChar != 'q') ;
        }
    }
}
