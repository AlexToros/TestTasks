using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling
{
    public class DefaultFileHandler : FileHandler
    {
        public DefaultFileHandler() : base(null) { }
        public override bool CanHandle(string extension) => true;
    }
}
