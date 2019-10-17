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
        void Handle(string fileContent, string fileName);
        bool CanHandle(string fileContent);
    }
}
