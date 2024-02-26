using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGradeApp
{
    public abstract class GenreBase : IGenre
    {
       // private List<Track> tracks;
       // jak dodac prywatna liste do kontruktora w klasie dziedziczace (GenreInMemory)
        public string MusicGenre { get; private set; }

        public GenreBase(string musicGenre)
        {
            MusicGenre = musicGenre;
        }

        public abstract void AddTrack(string title, float rating);
        public abstract void AddTrack(string title, string rating);
        public abstract void ShowTracks();
        public abstract Statistics GetStatistics();
       
    }
}
