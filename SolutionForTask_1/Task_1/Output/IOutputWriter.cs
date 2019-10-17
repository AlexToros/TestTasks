using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling;

namespace Task_1.Output
{
    public interface IOutputWriter
    {
        void Write(HandleResult output);
    }
}
