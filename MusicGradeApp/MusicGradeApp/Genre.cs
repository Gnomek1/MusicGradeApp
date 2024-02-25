using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGradeApp
{
    public class Genre
    {
        public List<Track> tracks;
        public string MusicGenre { get;  private set; }

        public Genre (string musicGenre)
        {
            tracks = new List<Track> ();
            MusicGenre = musicGenre;
        }

        public void AddTrack(string title,float rating) 
        {
            if (rating>=0 && rating <= 100)
            {
                Track track = new Track(title, rating);
                tracks.Add(track);
            }
            else
            {
                Console.WriteLine("Please enter rate between 0 and 100");
            }
        }
        public void AddTrack(string title, string rating)
        {
            if(float.TryParse(rating, out float result))
            {
                AddTrack(title,result);
            }
            else
            {
                Console.WriteLine("enter valid string");
            }
        }
        public  Statistics GetStatistics()
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
