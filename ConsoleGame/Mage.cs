using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Mage : Player
    {
        public Mage(string name)
        {
            this.name = name;
        }

        public override string Type()
        {
            return "Mago";
        }
        public override string Avatar()
        {
            return "mage";
        }
        public override string Protection()
        {
            return "Porção de Proteção";
        }
        public override string ProtectionAscii()
        {
            return "portion.asc";
        }
        public override ConsoleColor AvatarColor()
        {
            return ConsoleColor.Gray;
        }
    }
}
