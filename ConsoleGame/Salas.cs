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
        public List<Item> items = new List<Item>();
        char[,] Matrix = new char[100, 100];
        int[] MatrixSize = new int[2];
        string[] movimentos = new string[100];

        public void Draw()
        {
            Console.SetCursorPosition(1, 1);
            for(int i = 0; i < MatrixSize[0]; i++)
            {
                for (int j = 0; j < MatrixSize[1]; j++) Console.Write(Matrix[j,i]);
                Console.WriteLine();
            }
        }
        public void Open(string file)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(path);
            file = directory + "\\..\\..\\" + file;

            int top = 0;
            int left = 0;
            bool end_of_map = false;
            int movimento_idx = 0;

            using (FileStream fs = File.OpenRead(file))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
               
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string elementos = temp.GetString(b);
                    for (int i = 0; i < elementos.Length; i++) {
                        if (elementos[i] == (char)0 || elementos[i] == (char)10 ) continue;
                        if (elementos[i] == 'Z') { end_of_map = true; continue; }

                        if( end_of_map )
                        {
                            if (elementos[i] == (char)13) movimento_idx++;
                            else this.movimentos[movimento_idx] = $"{this.movimentos[movimento_idx]}{elementos[i]}";
                        } else
                        {
                            if (elementos[i] == '+' || elementos[i] == '-' || elementos[i] == '|')
                            {
                                this.Matrix[left, top] = elementos[i];
                                left++;
                            }
                            else if (elementos[i] == (char)13)
                            {
                                left = 0;
                                top++;
                            }
                            else
                            {
                                Item item = new Item(elementos[i], left, top);
                                this.Matrix[left, top] = item.output;
                                items.Add(item);
                                left++;
                            }
                        }
                        
                    }

                }
                MatrixSize[0] = left;
                MatrixSize[1] = top;
            }
        }
    }
}
