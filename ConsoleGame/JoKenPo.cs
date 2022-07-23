using System;
using System.Threading;
using static System.Console;

namespace ConsoleGame
{
    internal class JoKenPo : IFases
    {
        public Player player;
        public bool ganhou = false;
        private string enemy;

        public JoKenPo(Player player, string enemy= "esqueleto")
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Play()
        {
            /*************
             * Intro
             *************/
            Ascii.ResetBlue();
            Ascii.Show("template.asc");
            ForegroundColor = ConsoleColor.DarkYellow;
            Ascii.Show($"{enemy}.asc", 80, 5);
            player.DrawLife();
            ForegroundColor = ConsoleColor.White;

            if(enemy == "esmeagol")
            {
                Ascii.Type("Você caiu nesta sala junto com o Esmeagol!", 3, 2);
                Ascii.Type("Ele gosta muito de JoKenPo e só vai te deixar passar", 3, 3);
                Ascii.Type("se ganhar dele.", 3, 4);
                Ascii.Type("Você pode jogar quantas vezes quiser, mas cada vez", 3, 6);
                Ascii.Type("que perder, vai perder um pouco de vida!", 3, 7);
                Ascii.Type("E então? Aceita o desafio?", 3, 9);
            }
            else if (enemy == "esqueleto") 
            {
                Ascii.Type("Você deu de cara com um Esqueleto!", 3, 2);
                Ascii.Type("Ele gosta de jogar JoKenPo e só vai te deixar passar", 3, 3);
                Ascii.Type("se ganhar dele.", 3, 4);
                Ascii.Type("Você pode jogar quantas vezes quiser, mas cada vez", 3, 6);
                Ascii.Type("que perder, vai perder muito de vida!", 3, 7);
                Ascii.Type("E então? Aceita o desafio?", 3, 9);
            } else
            {
                Ascii.Type("Você chegou no temido Dragão!", 3, 2);
                Ascii.Type("Ele também gosta de jogar JoKenPo e só vai te deixar passar", 3, 3);
                Ascii.Type("se ganhar dele.", 3, 4);
                Ascii.Type("Você pode jogar quantas vezes quiser, mas cada vez", 3, 6);
                Ascii.Type("que perder, vai perder muito de vida!", 3, 7);
                Ascii.Type("E então? Aceita o desafio?", 3, 9);
            }
            

            string[] options = { "Pedra", "Papel", "Tesoura", "Desistir" };
            int game = 0;
            Random rnd = new Random();
            while (true)
            {
                game = Ascii.Selection(options, new int[] { 7, 35, 70, 100 }, new int[] { 30, 30, 30, 30 });
                if(game == 3) { break; }
                
                Ascii.ResetBlue();
                Ascii.Show("template.asc");
                ForegroundColor = ConsoleColor.DarkYellow;
                Ascii.Show($"{enemy}.asc", 80, 5);
                player.DrawLife();
                ForegroundColor = ConsoleColor.White;
                player.ShowAvatar(2, 1);
                Beep(440, 200);
                Thread.Sleep(200);
                Beep(440, 200);
                Thread.Sleep(200);
                Beep(440, 200);
                Thread.Sleep(800);
                Beep(880, 400);

                int enemy_play = rnd.Next(0, 2);
                Ascii.Show($"{options[game]}.asc", 35, 3);
                Ascii.Show($"{options[enemy_play]}.asc", 75, 3);
                Thread.Sleep(1000);
                if (enemy_play == game) {
                    ForegroundColor = ConsoleColor.Green;
                    BackgroundColor = ConsoleColor.DarkGreen;
                    Ascii.Show("ganhou.asc", 30, 10);
                    ganhou = true;
                    Music success = new Music("success");
                    success.Play();
                    break; 
                } else
                {
                    ForegroundColor = ConsoleColor.Red;
                    BackgroundColor = ConsoleColor.DarkRed;
                    Ascii.Show("perdeu.asc", 30, 10);
                    Beep(220, 400);

                    if (enemy == "esmeagol")
                    {
                        if (player.has_protection) player.Life(-10);
                        else player.Life(-20);
                    } else if (enemy == "esqueleto")
                    {
                        if (player.has_protection) player.Life(-5);
                        else player.Life(-10);
                    } else
                    {
                        if (player.has_protection) player.Life(-30);
                        else player.Life(-50);
                    }
                        
                    player.DrawLife();
                    Thread.Sleep(1000);
                    if (player.Life() <= 0) break;
                }

            }

        }
    }
}
