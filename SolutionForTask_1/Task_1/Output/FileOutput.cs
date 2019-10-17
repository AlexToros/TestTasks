using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling;

namespace Task_1.Output
{
    public class FileOutput : IOutputWriter
    {
        private readonly string path;

        public FileOutput(string outputPath)
        {
            path = outputPath;
        }

        public void Write(HandleResult output)
        {
            File.AppendAllText(path, output.ToString());
        }
    }
}
