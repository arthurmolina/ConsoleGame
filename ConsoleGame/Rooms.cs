using System;
using System.Collections.Generic;
using static System.Console;


namespace ConsoleGame
{
    internal class Rooms : IFases
    {
        private Dictionary<string, string[]> acoes = new Dictionary<string, string[]>();
        private string[] Matrix = new string[33];
        private Player player;
        private string current_room;

        public Rooms(string name, int class_chosen)
        {
            switch (class_chosen)
            {
                case 0:
                    player = new Warrior(name);
                    break;
                case 1:
                    player = new Mage(name);
                    break;
                case 2:
                    player = new Archer(name);
                    break;
            }
        }

        public void Play()
        {
            Open("sala1");
            Random rnd = new Random();

            while (true)
            {
                string[] acao_atual = Ascii.DefaultSelection(acoes);
                Beep(440, 20); //success

                switch (acao_atual[1])
                {
                    case "open":
                        if(rnd.Next(1,10) == 1)
                        {
                            JoKenPo jokenpo_open = new JoKenPo(this.player);
                            jokenpo_open.Play();
                            if (jokenpo_open.ganhou) Open(acao_atual[2]);
                            else Open(current_room);
                        } else
                        {
                            Open(acao_atual[2]);
                        }
                        
                        break;
                    case "maze":
                        Maze maze = new Maze();
                        maze.Play();
                        Open(acao_atual[2]);
                        break;
                    case "jokenpo":
                        JoKenPo jokenpo = new JoKenPo(this.player, acao_atual[3]);
                        jokenpo.Play();
                        if (jokenpo.ganhou) Open(acao_atual[2]);
                        else Open(current_room);
                        break;
                    case "chest":
                        player.AddItem(acao_atual[2]);
                        Open(current_room);
                        break;
                    case "getout":
                        Environment.Exit(0);
                        break;
                    case "end":
                        HappyEnding();
                        break;
                }
            }
            
        }

        private void HappyEnding()
        {
            Ascii.Reset();
            Ascii.Show("end.asc");
            Ascii.Type("Parabéns! Você salvou a princesa", 2, 9, 10);
            Ascii.Type("e agora foi condecorado como cavaleiro do rei!", 2, 10, 10);
            SetCursorPosition(0, 33);
            Music death = new Music("death");
            death.Play();
            ReadLine();
            Environment.Exit(0);
        }

        private void Draw()
        {
            SetCursorPosition(0, 0);
            Ascii.Reset();
            foreach(string line in Matrix) WriteLine(line);
        }

        private void Open(string file)
        {
            if (player.Life() > 0)
            {
                current_room = file;
                string[] lines = Ascii.Get($"{file}.txt");
                for (int i = 0; i < Matrix.Length; i++) Matrix[i] = lines[i];
                this.acoes.Clear();
                for (int i = 33; i < lines.Length; i++)
                {
                    string[] acoes = lines[i].Split(';');
                    this.acoes.Add(acoes[0], acoes);
                }
                Draw();
                player.DrawLife();
            } else
            {
                Dead();
            }
        }

        private void Dead()
        {
            Ascii.Reset();
            Ascii.Show("death.asc", 50, 1);
            Ascii.Show("dead.asc", 2, 3);
            Ascii.Type("Não foi dessa vez...", 2, 9, 10);
            SetCursorPosition(0, 33);
            Music death = new Music("death");
            death.Play();
            ReadLine();
            Environment.Exit(0);

        }
    }
}
