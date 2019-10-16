using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling
{
    public interface IFileHandler
    {
        IEnumerable<HandleResult> Handle(FileInfo file);
        bool CanHandle(FileInfo file);
    }
}
