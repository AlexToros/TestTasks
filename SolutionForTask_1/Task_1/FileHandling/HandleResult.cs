using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling
{
    /// <summary>
    /// Результат работы обработчика контента
    /// </summary>
    public class HandleResult
    {
        public string FileName { get; set; }
        public string OperationName { get; set; }
        public string OperationResult { get; set; }

        public override string ToString()
        {
            return $"{FileName}-{OperationName}-{OperationResult}";
        }
    }
}
