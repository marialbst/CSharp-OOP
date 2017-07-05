using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    class Program
    {
        private const string InvalidSongLengthException = "Invalid song length.";//t6

        static void Main(string[] args)
        {
            List<Song> playList = ReadSongs();
            Console.WriteLine($"Songs added: {playList.Count}");
            TimeSpan timeInSec = TimeSpan.FromSeconds(playList.Sum(s=>s.TotalLength.TotalSeconds));
            Console.WriteLine($"Playlist length: {timeInSec.Hours}h {timeInSec.Minutes}m {timeInSec.Seconds}s");
        }

        private static List<Song> ReadSongs()
        {
            List<Song> songs = new List<Song>();
            int songCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < songCount; i++)
            {
                var input = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    int[] lengths = new int[2];
                    try
                    {
                        lengths = input[2].Split(new []{':'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException(InvalidSongLengthException);
                    }

                    Song song = new Song(input[0], input[1],lengths[0],lengths[1]);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return songs;
        }
    }
}
