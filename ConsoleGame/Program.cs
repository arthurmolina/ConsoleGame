using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.SetCursorPosition(10, 10);
            Salas salas = new Salas();
            salas.Open("./sala01.txt");
            salas.Draw();
            Console.ReadKey();

        }
    }
}
