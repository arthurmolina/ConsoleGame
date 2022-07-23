using System;
using System.Collections.Generic;
using static System.Console;
using System.Threading;

namespace ConsoleGame
{
    internal class Music
    {
        public List<int[]> partiture = new List<int[]>();
        public int position = 0;

        public Music(string file)
        {
            open_file($"{file}.mus");
        }

        public void Play()
        {
            foreach(int[] nota in partiture)
                OneNote(nota);
        }

        public void PlayNote()
        {
            if (position >= partiture.Count) position = 0;
            OneNote(partiture[position]);
            position++;
        }

        private void OneNote(int[] nota)
        {
            Beep(nota[0], nota[1]);
            Thread.Sleep(nota[2]);
        }

        private void open_file(string file)
        {
            string[] lines = Ascii.Get(file);
            foreach (string line in lines)
            {
                string[] notes = line.Split(',');
                int[] notes_int = new int[notes.Length];
                for (int j = 0; j < 3; j++) notes_int[j] = Int32.Parse(notes[j]);
                partiture.Add(notes_int);
            }
        }
    }
}
