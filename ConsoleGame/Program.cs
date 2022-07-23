using System;
using static System.Console;


namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.Gray, ConsoleColor.White };
            int color_position = 0;

            //OutputEncoding = Encoding.GetEncoding(28591);
            /*****************
             * Inicio
             * **************/
            Ascii.Reset();
            Music music = new Music("intro2");
            Ascii.Show("intro.asc");
            while (!KeyAvailable)
            {
                music.PlayNote();
                ForegroundColor = colors[color_position];
                color_position++;
                if (color_position >= colors.Length) color_position = 0;
                SetCursorPosition(26, 28);
                Write("Pressione qualquer tecla para continuar");
            }
            ReadKey();

            /******************
             * Choose Class
             ******************/
            Ascii.ResetBlue();
            Ascii.Show("choose_class.asc");
            ForegroundColor = ConsoleColor.Yellow;
            Ascii.Show("warrior.asc", 3, 1);
            ForegroundColor = ConsoleColor.Gray;
            Ascii.Show("mage.asc", 35, 1);
            ForegroundColor = ConsoleColor.Green;
            Ascii.Show("archer.asc", 76, 1);
            string[] classes = { "Guerreiro", "Mago", "Arqueiro" };
            int class_chosen = Ascii.Selection( classes, new int[] { 7, 59, 100}, new int[] { 30, 30, 30 } );
            Music success = new Music("success");
            success.Play();

            /*********************
             * Choose Name
             *********************/
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            for (int i = 27; i <= 31; i++)
            {
                SetCursorPosition(3, i);
                Write("                                                                                                                     ");
            }            
            SetCursorPosition(3, 28);
            Write($"Informe o nome do seu {classes[class_chosen]}: ");
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            string name = ReadLine();
            success.Play();

            /********************
             * Explain
             ********************/
            Ascii.Reset();
            ForegroundColor = ConsoleColor.DarkYellow;
            BackgroundColor = ConsoleColor.Yellow;
            Ascii.Show("intro_explanation.asc");
            ForegroundColor = ConsoleColor.Black;
            Ascii.Type($"Benvindo, {classes[class_chosen]} {name}!", 9, 13);
            Ascii.Type("O reino foi assolado por criaturas malignas e o castelo foi invadido por um poderoso dragão.", 9, 15);
            Ascii.Type("Os ocupantes conseguiram fugir do castelo, mas justamente a princesa Zelda de Almeida não", 9, 17);
            Ascii.Type("conseguiu sair e foi capturada pelo dragão.", 9, 18);
            Ascii.Type("O Rei, temendo pela vida de sua filha, fez uma chamada aos mais corajosos cavaleiros,", 9, 20);
            Ascii.Type("magos e outros guerreiros prometendo ouro e a mão de sua filha.", 9, 21);
            Ascii.Type("E aí? Você topa o desafio?", 9, 23);
            Music explain_music = new Music("bach");
            while (!KeyAvailable)
            {
                explain_music.PlayNote();
                ForegroundColor = colors[color_position];
                color_position++;
                if (color_position >= colors.Length) color_position = 0;
                SetCursorPosition(43, 31);
                Write("Pressione ENTER para continuar...");
            }
            ReadKey();

            Rooms room = new Rooms(name, class_chosen);
            room.Play();
        }
    }
}
