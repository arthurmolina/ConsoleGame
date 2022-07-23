using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleGame
{
    abstract class Player
    {
        protected string name = "";
        protected int life = 100;
        protected List<string> inventory = new List<string>();
        public bool has_protection = false;

        abstract public string Type();
        abstract public string Avatar();
        abstract public string Protection();
        abstract public string ProtectionAscii();
        abstract public ConsoleColor AvatarColor();

        public void ShowAvatar(int left, int top)
        {
            ConsoleColor old_color = Console.ForegroundColor;
            Console.ForegroundColor = AvatarColor();
            Ascii.Show($"{Avatar()}.asc", left, top);
            Console.ForegroundColor = old_color;
        }

        public int Life()
        {
            return life;
        }

        public int Life(int add_or_substract)
        {
            this.life += add_or_substract;
            return life;
        }

        public void AddItem(string item)
        {
            Ascii.ResetBlue();
            Ascii.Show("template.asc");
            ForegroundColor = ConsoleColor.White;
            Ascii.Show("chest.asc", 30, 10);
            if (inventory.Contains(item))
            {
                // Já possui!
                Ascii.Type("O baú está vazio. Você já veio aqui.", 4, 28);
            } else
            {
                inventory.Add(item);
                switch (item)
                {
                    case "life_portion":
                        Life(20);
                        DrawLife();
                        Ascii.Show("portion.asc", 60, 3);
                        Ascii.Type("Você achou uma porção de vida! Sua barra de vida aumentou 20 pontos.", 4, 28);
                        break;
                    case "protection":
                        has_protection = true;
                        Ascii.Show(ProtectionAscii(), 60, 1);
                        Ascii.Type($"Você achou {Protection()}!", 4, 28);
                        break;
                }
            }
            ReadKey();
            
        }

        public List<string> Inventory()
        {
            return inventory;
        }

        public string Name()
        {
            return name;
        }
        public void DrawLife() {
            ConsoleColor old_color = ForegroundColor;
            ConsoleColor old_color_bg = BackgroundColor;
            ForegroundColor = ConsoleColor.Green;
            BackgroundColor = ConsoleColor.Black;
            SetCursorPosition(5, 26);
            int total = 50;
            if(inventory.Contains("life_portion")) total = 60;

            Write(" Vida ");
            for (int i = 0; i < Life()/2; i++) { Write("█"); }
            ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < total-Life()/2; i++) { Write("█"); }
            ForegroundColor = old_color;
            BackgroundColor = old_color_bg;
        }
    }
}
