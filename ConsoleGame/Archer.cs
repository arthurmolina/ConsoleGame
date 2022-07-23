using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Archer : Player
    {
        public Archer(string name)
        {
            this.name = name;
        }

        public override string Type()
        {
            return "Arqueiro";
        }

        public override string Avatar()
        {
            return "archer";
        }

        public override string Protection()
        {
            return "Cota de Malha";
        }
        public override string ProtectionAscii()
        {
            return "armory.asc";
        }

        public override ConsoleColor AvatarColor()
        {
            return ConsoleColor.Green;
        }

    }
}
