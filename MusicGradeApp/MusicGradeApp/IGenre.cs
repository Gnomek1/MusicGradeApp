using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGradeApp
{
    public interface IGenre
    {
        string MusicGenre { get; }

        void AddTrack(string title, int rating);
        void AddTrack(string title, string rating);
        Statistics GetStatistics();
    }
}
