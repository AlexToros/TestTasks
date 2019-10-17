using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileHandling;

namespace Task_1.Watcher
{
    public interface IWatcher : IDisposable
    {
        void Start();
        void AddHandler(IFileHandler fileHandler);
    }
}
