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
        private readonly string divPattern = "";

        public string HandlerName => "Подсчет количества блоков div";

        public string Handle(string fileContent)
        {
            return $"Количество тегов div: {Regex.Match(fileContent, divPattern).Groups[1].Captures.Count}";
        }
    }
}
