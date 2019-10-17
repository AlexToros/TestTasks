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
            try
            {
                handlers = new List<IFileHandler>();
                watcher = new FileSystemWatcher(path);
                ConfigureWatcher();
            }
            catch (ArgumentException ex)
            {
                var e = new ArgumentException($"Проблемы с доступом к папке {path}", ex);
                throw e;
            }
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
                   Task.Delay(50).Wait();
                   string fileContent = File.ReadAllText(e.FullPath);
                   bool wasHandled = false;
                   foreach (var h in handlers)
                   {
                       bool canHandle = h.CanHandle(Path.GetExtension(e.Name));
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
