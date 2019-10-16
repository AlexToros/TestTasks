using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling.ContentHandling
{
    public interface IContentHandler
    {
        string HandlerName { get; }
        string Handle(FileInfo file);
    }
}
