using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling.ContentHandling
{
    public class PunctuationCounter : IContentHandler
    {
        public string HandlerName => "Подсчет знаков препинания";

        public string Handle(string fileContent)
        {
            return $"{fileContent.Count(Char.IsPunctuation)}";
        }
    }
}
