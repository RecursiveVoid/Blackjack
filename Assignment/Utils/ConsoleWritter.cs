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
        public static void WriteRegular(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            _write(text);

        }

        private static void _write(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
        }

        public static void WriteInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _write(text);
        }

        public static void WriteInYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            _write(text);
        }

        public static void WriteInGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _write(text);
        }
    }
}
