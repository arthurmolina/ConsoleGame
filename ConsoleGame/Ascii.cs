using System;
using static System.Console;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
{
    static class Ascii
    {
        public static string[] Get(string file)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(path);
            file = directory + "\\..\\..\\assets\\" + file;
            return System.IO.File.ReadAllLines(file);
        }

        public static void Show(string file, int left = 0, int top=0)
        {
            string[] lines = Get(file);
            foreach(string line in lines)
            {
                SetCursorPosition(left, top);
                Write(line);
                top++;
            }
        }

        public static void ResetBlue()
        {
            ForegroundColor = ConsoleColor.Blue;
            BackgroundColor = ConsoleColor.Black;
            Clear();
        }

        public static void Reset()
        {
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            Clear();
        }

        public static void Type(string what, int left, int top, int wait=20)
        {
            for(int i = 0; i < what.Length; i++)
            {
                SetCursorPosition(i+left, top);
                Write(what[i]);
                Thread.Sleep(wait);
            }
        }

        public static string[] DefaultSelection(Dictionary<string, string[]> acoes)
        {
            string[] keys = acoes.Keys.ToArray();
            int space = 0;
            foreach (string key in keys) space += key.Length + 2; //122 de coluna - 3 de cada lado = 116 -- meio 58
            space += (keys.Length - 1) * 2;
            int new_left = (116 - space)/2 ;

            int[] left = new int[keys.Length];
            for(int i = 0; i < left.Length; i++)
            {
                left[i] = new_left;
                new_left += 2 + keys[i].Length;
            }
            int[] top = new int[keys.Length];
            for (int i = 0; i < top.Length; i++) top[i] = 30;
            int selected = Selection(keys, left, top);

            acoes.TryGetValue(keys[selected], out string[] acao_atual);

            return acao_atual;
        }

        public static int Selection(string[] options, int[] left, int[] top)
        {
            int selected = 0;
            bool sair = false;
            do
            {
                Select(options, left, top, selected);
                switch(ReadKey().Key) {
                    case ConsoleKey.Enter:
                        sair = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                        selected--;
                        if(selected < 0) selected = options.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                        selected++;
                        if (selected >= options.Length) selected = 0;
                        break;
                }
            } while (!sair);
            return selected;
        }

        private static void Select(string[] options, int[] left, int[] top, int selected)
        {
            for(int i = 0; i < options.Length; i++)
            {
                SetCursorPosition(left[i], top[i]);
                if(selected == i)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                } else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                Write($" {options[i]} ");
            }
        }
    }
}
