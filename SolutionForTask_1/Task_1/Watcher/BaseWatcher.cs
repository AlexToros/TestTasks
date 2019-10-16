using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling;
using Task_1.Output;

namespace Task_1.Watcher
{
    public class BaseWatcher : IWatcher
    {
        private List<IFileHandler> handlers;
        private FileSystemWatcher watcher;
        private IOutputWriter writer;

        public IFileHandler DefaultHandler { get; set; }
        public BaseWatcher()
        {
            handlers = new List<IFileHandler>();
            watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["ObservableDirectory"]);
        }
        
        public void Start()
        {
            watcher.Filter = "*.*";
            watcher.Created += Watcher_Created;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);
            foreach (var handler in handlers.Where(h => h.CanHandle(fi)))
            {
                foreach (var handleResult in handler.Handle(fi))
                {
                    writer.Write(handleResult.ToString());
                }
            }
        }

        public void Add(IFileHandler fileHandler)
        {
            handlers.Add(fileHandler);
        }

        public void Dispose()
        {
            watcher.Dispose();
        }
    }
}
