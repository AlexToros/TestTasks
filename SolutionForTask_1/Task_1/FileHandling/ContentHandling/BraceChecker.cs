using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileHandling.ContentHandling
{
    public class BraceChecker : IContentHandler
    {
        private Dictionary<char, char> braces; 

        public string HandlerName => "Проверка валидности фигурных скобок";
        
        /// <summary>
        /// Осуществляет проверку на валидность расстановки скобок
        /// </summary>
        /// <param name="checkingBraces">словарь пар скобок. Ключ - закрывающая скобка</param>
        public BraceChecker(Dictionary<char, char> checkingBraces)
        {
            braces = checkingBraces;
        }

        public string Handle(string fileContent)
        {
            return Check(fileContent) ? "Положительно" : "Отрицательно";
        }

        private bool Check(string fileContent)
        {
            Stack<char> buffer = new Stack<char>();
            foreach (char brace in fileContent.Where(c => braces.Keys.Contains(c) || braces.Values.Contains(c)))
            {
                if (braces.TryGetValue(brace, out char openBrace))
                {
                    if (buffer.Count == 0 || buffer.Pop() != openBrace) return false;
                }
                else
                    buffer.Push(brace);
            }
            return buffer.Count == 0;
        }
    }
}
