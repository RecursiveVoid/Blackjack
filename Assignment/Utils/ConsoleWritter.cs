using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Utils
{
    public static class ConsoleWritter
    {
        public static void WriteHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var textLenght = text.Length;
            var separator = new string('-', textLenght);
            Console.WriteLine();
            Console.WriteLine(separator);
            Console.WriteLine(text.ToUpper());
            Console.WriteLine(separator);
            Console.WriteLine();
        }
        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            _switchColor(color);
            Console.WriteLine();
            Console.WriteLine(text);
        }

        private static void _switchColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
