using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling;
using Task_1.FileHandling.ContentHandling;
using Task_1.Output;
using Task_1.Watcher;

namespace Task_1.Config
{
    public class MainConfigurator : IConfigurator
    {
        public IWatcher GetWatcher()
        {
            string outputPath = ConfigurationManager.AppSettings["OutputPath"];
            string pathToWatch = ConfigurationManager.AppSettings["ObservableDirectory"];

            var output = new FileOutput(outputPath);
            var watcher = new CommonWatcher(pathToWatch);            
            var httpHandler = new FileHandler(".http");
            var cssHandler = new FileHandler(".css");
            var defaultHandler = new DefaultFileHandler();

            httpHandler.Add(new DivCounter());
            httpHandler.HandleComplete += output.Write;

            defaultHandler.Add(new PunctuationCounter());
            defaultHandler.HandleComplete += output.Write;

            cssHandler.Add(
                new BraceChecker(
                    new Dictionary<char, char> {
                        { '}', '{'}
                    }));
            cssHandler.HandleComplete += output.Write;

            watcher.AddHandler(httpHandler);
            watcher.DefaultHandler = defaultHandler;

            return watcher;
        }
    }
}
