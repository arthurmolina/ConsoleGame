using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Salas
    {
        int[] PosicaoPlayer = { 0, 0 };
        
        public void Open(string file)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(path);
            file = directory + "\\..\\..\\" + file;
            List<Item> items = new List<Item>();
            int linha = 2;

            using (FileStream fs = File.OpenRead(file))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                Console.SetCursorPosition(2, linha);
               
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string elementos = temp.GetString(b);
                    for (int i = 0; i < elementos.Length; i++) {
                        if (elementos[i] == (char)0 || elementos[i] == (char)10 ) continue;
                        if (elementos[i] == '+' || elementos[i] == '-' || elementos[i] == '|' )
                            Console.Write(elementos[i]);
                        else if (elementos[i] == (char)13)
                        {
                            linha++;
                            Console.SetCursorPosition(2, linha);
                            continue;
                        }
                        else
                        {
                            Item item = new Item(elementos[i]);
                            Console.Write(item.output);
                            items.Add(item);
                        }
                    }
                    //Console.WriteLine();

                }
            }
        }
    }
}
