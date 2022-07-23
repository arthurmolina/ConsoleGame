using System;
using static System.Console;
using System.Threading;


namespace ConsoleGame
{
    internal class Maze : IFases
    {
        public string[] matriz;
        public int[] localizacao = { 0, 0 };
        public int[] saida = { 0, 0 };

        public Maze(string qual="1")
        {
            matriz = Ascii.Get($"maze{qual}.txt");
        }

        private void Draw()
        {
            bool ja_escrito = false;
            Ascii.Reset();
            ForegroundColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.DarkYellow;
            for(int i = 0; i < matriz.Length; i++)
            {
                WriteLine(matriz[i]);
                int local = matriz[i].IndexOf('*');
                if(local >= 0)
                {
                    localizacao[1] = i;
                    localizacao[0] = local;
                }

                local = matriz[i].IndexOf('X');
                if (local >= 0 && !ja_escrito)
                {
                    saida[1] = i;
                    saida[0] = local;
                    ja_escrito = true;
                }
            }
            ForegroundColor = ConsoleColor.Red;
            SetCursorPosition(saida[0], saida[1]);
            Write("X");
            ForegroundColor = ConsoleColor.Blue;
            SetCursorPosition(localizacao[0], localizacao[1]);
            Write("*");

        }

        public void Play()
        {
            Draw();
            while(!Ganhou())
            {
                Move(ReadKey(false).Key);
            }
        }

        private bool Ganhou()
        {

            if (localizacao[0] == saida[0] && localizacao[1] == saida[1])
            {
                Music success = new Music("success");
                success.Play();
                return true;
            }
            return false;
        }

        private void Move(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    Movendo(localizacao[0], localizacao[1]-1);
                    break;
                case ConsoleKey.DownArrow:
                    Movendo(localizacao[0], localizacao[1]+1);
                    break;
                case ConsoleKey.LeftArrow:
                    Movendo(localizacao[0]-1, localizacao[1]);
                    break;
                case ConsoleKey.RightArrow:
                    Movendo(localizacao[0]+1, localizacao[1]);
                    break;
            }
            SetCursorPosition(0, 0);
            //Write($"{localizacao[0]}, {localizacao[1]}");
        }

        private void Movendo(int new_left, int new_top)
        {
            if (CanMove(new_left, new_top))
            {
                SetCursorPosition(localizacao[0], localizacao[1]);
                Write(' ');
                localizacao[0] = new_left;
                localizacao[1] = new_top;
                SetCursorPosition(localizacao[0], localizacao[1]);
                Write('*');
                Beep(440, 20);
            }
            else
            {
                Beep(240,60);
            }
        }

        private bool CanMove(int left, int top)
        {
            if (top < 0 || left < 0 || top >= matriz.Length || left >= matriz[0].Length) return false;
            return matriz[top][left] == ' ' || matriz[top][left] == 'X';
        }
    }
}
