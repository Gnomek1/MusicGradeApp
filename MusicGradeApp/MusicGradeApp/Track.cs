using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGradeApp
{
    public class Track
    {
        public string Title { get; private set; }
        public int Rating { get; private set; }

        public Track(string title, int rating)
        {
            Title = title;
            Rating = rating;
        }
    }
}
