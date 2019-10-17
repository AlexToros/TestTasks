using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_1.FileHandling.ContentHandling
{
    public class DivCounter : IContentHandler
    {
        public string HandlerName => "Подсчет количества блоков div";

        public string Handle(string fileContent)
        {
            return $"{divCount(fileContent)}";
        }

        private int divCount(string fileContent)
        {
            int count = 0;
            int indx = -1;
            while ((indx = fileContent.IndexOf("<div>", indx + 1)) != -1)
                count++;
            return count;
        }
    }
}
