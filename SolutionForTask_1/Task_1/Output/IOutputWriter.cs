using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Output
{
    public interface IOutputWriter : IDisposable
    {
        void Write(string output);
    }
}
