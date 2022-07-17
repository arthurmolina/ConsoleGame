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
        public string output = "";
        public Item(char tipo)
        {
            this.Tipo = tipo;
            switch (Tipo)
            {
                case 'A': 
                    this.Nome = "Arca";
                    this.output = "^";
                    break;
                case 'I':
                    this.Nome = "Inimigo";
                    this.output = "@";
                    break;
                case 'P':
                    this.Nome = "Personagem";
                    this.output = "$";
                    break;
                case 'U':
                case 'D':
                case 'R':
                case 'L':
                    this.Nome = "Movimento";
                    this.output = " ";
                    break;
                default: 
                    this.Nome = "Nada";
                    this.output = $"{tipo}";
                    break;
            }
        }
    }
}
