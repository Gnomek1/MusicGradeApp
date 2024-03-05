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

        public abstract void AddTrack(string title, int rating);
        public abstract void AddTrack(string title, string rating);
        public abstract void AddTrack(string title, double rating);
        public abstract void ShowTracks();
        public abstract Statistics GetStatistics();
    }
}
