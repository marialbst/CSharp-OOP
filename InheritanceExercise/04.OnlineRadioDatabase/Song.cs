using System;

namespace _04.OnlineRadioDatabase
{
    public class Song
    {
        private const string InvalidSongException = "Invalid song.";
        private const string InvalidArtistNameException = "Artist name should be between 3 and 20 symbols.";//t1
        private const string InvalidSongNameException = "Song name should be between 3 and 30 symbols.";//t2
        private const string InvalidSongMinutesException = "Song minutes should be between 0 and 14.";//t4
        private const string InvalidSongSecondsException = "Song seconds should be between 0 and 59.";//t3,z1

        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;
        private TimeSpan totalLength;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.totalLength = CalcTotal();
        }

        private TimeSpan CalcTotal()
        {
            return TimeSpan.FromSeconds(this.Minutes * 60 + this.Seconds);
        }

        public string ArtistName
        {
            get { return this.artistName; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException(InvalidArtistNameException);
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException(InvalidSongNameException);
                }

                this.songName = value;
            }
        }

        public TimeSpan TotalLength
        {
            get { return this.totalLength; }
        }

        public int Minutes
        {
            get { return this.minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException(InvalidSongMinutesException);
                }
                this.minutes = value;
            }
        }

        public int Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException(InvalidSongSecondsException);
                }
                this.seconds = value;
            }
        }
    }
}
