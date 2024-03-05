namespace MusicGradeApp
{
    public abstract class GenreBase : IGenre
    {
        public string MusicGenre { get; private set; }
        public abstract event AddTrackDelegate TrackAdded;
        public delegate void AddTrackDelegate(object sender, EventArgs args);
        public GenreBase(string musicGenre)
        {
            MusicGenre = musicGenre;
        }
        public abstract void ShowTracks();
        public abstract Statistics GetStatistics();
        public abstract void AddTrack(string title, int rating);
        public void AddTrack(string title, string rating)
        {
            if (int.TryParse(rating, out int result))
            {
                AddTrack(title, result);
            }
            else
            {
                throw new Exception("Please enter integer between 0 and 100");
            }
        }
        public void AddTrack(string title, double rating)
        {
            int ratingAsDouble = (int)rating;
            AddTrack(title, ratingAsDouble);
        }
    }
}
