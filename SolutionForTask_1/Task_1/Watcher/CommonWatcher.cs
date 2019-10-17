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
    public class CommonWatcher : IWatcher
    {
        private FileSystemWatcher watcher;
        private List<IFileHandler> handlers;
      
        public IFileHandler DefaultHandler { get; set; }

        public CommonWatcher(string path)
        {
            handlers = new List<IFileHandler>();
            watcher = new FileSystemWatcher(path);
            ConfigureWatcher();
        }

        protected virtual void ConfigureWatcher()
        {
            watcher.Filter = "*.*";
            watcher.Created += Watcher_Created;
        }
        
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Task.Run(() =>
               {
                   string fileContent = File.ReadAllText(e.FullPath);
                   bool wasHandled = false;
                   foreach (var h in handlers)
                   {
                       bool canHandle = h.CanHandle(Path.GetExtension(fileContent));
                       wasHandled |= canHandle;
                       if (canHandle)
                           h.Handle(fileContent, e.Name);
                   }

                   if (!wasHandled)
                       DefaultHandler?.Handle(fileContent, e.Name);
               });
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void AddHandler(IFileHandler fileHandler)
        {
            handlers.Add(fileHandler);
        }

        public void Dispose()
        {
            watcher.Dispose();
        }
    }
}
