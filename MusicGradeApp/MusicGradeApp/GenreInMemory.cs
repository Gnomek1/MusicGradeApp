namespace MusicGradeApp
{
    public class GenreInMemory : GenreBase
    {
        private List<Track> tracks;
        public override event AddTrackDelegate TrackAdded;
        public GenreInMemory(string musicGenre) : base(musicGenre)
        {
            tracks = new List<Track>();
        }

        public override void AddTrack(string title, int rating)
        {
            if (rating >= 0 && rating <= 100)
            {
                Track track = new Track(title, rating);
                tracks.Add(track);
                if (TrackAdded != null)
                {
                    TrackAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Please enter integer  between 0 and 100");
            }
        }

        public override void ShowTracks()
        {
            foreach (var item in tracks)
            {
                switch (item.Rating)
                {
                    case >= 80:
                        Console.WriteLine($"{item.Title} A");
                        break;
                    case >= 60:
                        Console.WriteLine($"{item.Title} B");
                        break;
                    case >= 40:
                        Console.WriteLine($"{item.Title} C");
                        break;
                    case >= 20:
                        Console.WriteLine($"{item.Title} D");
                        break;
                    default:
                        Console.WriteLine($"{item.Title} E");
                        break;
                }
            }
        }
        public override Statistics GetStatistics()
        {
            Statistics stat = new Statistics();

            foreach (var item in this.tracks)
            {
                stat.AddGrade(item.Rating);
            }
            return stat;
        }

    }
}
