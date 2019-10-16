using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling.ContentHandling;

namespace Task_1.FileHandling
{
    public abstract class BaseFileHandler : IFileHandler
    {
        protected List<IContentHandler> Handlers;
        protected List<string> EnableExtensions;
        protected StreamWriter outputStream;

        public BaseFileHandler()
        {
            EnableExtensions = new List<string>();
            Handlers = new List<IContentHandler>();
            outputStream = File.AppendText(ConfigurationManager.AppSettings["outputFilePath"]);
        }

        public IEnumerable<HandleResult> Handle(FileInfo file)
        {
            foreach(var h in Handlers)
            { 
                string result = h.Handle(file);
                yield return new HandleResult
                {
                    FileName = file.Name,
                    OperationName = h.HandlerName,
                    OperationResult = result
                }; 
            }                
        }

        public void Add(IContentHandler handler)
        {
            Handlers.Add(handler);
        }
        
        public bool CanHandle(FileInfo file)
        {
            return EnableExtensions.Contains(file.Extension);
        }
    }
}
