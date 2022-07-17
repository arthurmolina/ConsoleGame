using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Item
    {
        public string Nome;
        public char Tipo;
        public char output;
        public int left = 0;
        public int top = 0;
        public Item(char tipo, int left, int top)
        {
            this.Tipo = tipo;
            this.left = left;
            this.top = top;
            switch (Tipo)
            {
                case 'A': 
                    this.Nome = "Arca";
                    this.output = '^';
                    break;
                case 'I':
                    this.Nome = "Inimigo";
                    this.output = '@';
                    break;
                case 'P':
                    this.Nome = "Personagem";
                    this.output = '$';
                    break;
                case 'U':
                case 'D':
                case 'R':
                case 'L':
                    this.Nome = "Movimento";
                    this.output = ' ';
                    break;
                default: 
                    this.Nome = "Nada";
                    this.output = tipo;
                    break;
            }
        }

        public void Move(string mover)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(' ');

            switch (mover)
            {
                case "UP":
                    top--;
                    break;
                case "DOWN":
                    top++;
                    break;
                case "LEFT":
                    left--;
                    break;
                case "RIGHT":
                    left++;
                    break;

            }
            Console.SetCursorPosition(left, top);
            Console.Write(this.output);
        }
    }
}
