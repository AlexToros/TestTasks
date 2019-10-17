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
    public class FileHandler : IFileHandler
    {
        protected string[] EnableExtensions;
        protected List<IContentHandler> Handlers;

        public event Action<HandleResult> HandleComplete;

        public FileHandler(IEnumerable<string> extensions) : this(extensions.ToArray()) { }

        public FileHandler(params string[] extensions)
        {
            EnableExtensions = extensions;
            Handlers = new List<IContentHandler>();
        }

        public virtual void Handle(string fileContent, string fileName)
        {
            foreach (var h in Handlers)
            { 
                string result = h.Handle(fileContent);
                HandleComplete?.Invoke(new HandleResult
                {
                    FileName = fileName,
                    OperationName = h.HandlerName,
                    OperationResult = result
                }); 
            }                
        }

        public void Add(IContentHandler handler)
        {
            Handlers.Add(handler);
        }
        
        public virtual bool CanHandle(string extension)
        {
            return EnableExtensions.Contains(extension);
        }
        
    }
}
