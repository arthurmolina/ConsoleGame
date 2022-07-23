using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Warrior : Player
    {
        public Warrior(string name)
        {
            this.name = name;
        }

        public override string Type()
        {
            return "Guerreiro";
        }
        public override string Avatar()
        {
            return "warrior";
        }

        public override string Protection()
        {
            return "Escudo";
        }
        public override string ProtectionAscii()
        {
            return "shield.asc";
        }
        public override ConsoleColor AvatarColor()
        {
            return ConsoleColor.Yellow;
        }
    }
}
