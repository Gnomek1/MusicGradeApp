﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicGradeApp
{
    public class GenreInFile : GenreBase
    {
        public delegate void AddTrackDelegate(object sender, EventArgs args);
        public event AddTrackDelegate TrackAdded;
        private readonly string fileName;
        private List<Track> tracks;

        public GenreInFile(string musicGenre) : base(musicGenre)
        {
            tracks = new List<Track>();
            fileName = musicGenre + "rating.txt";
        }

        public override void AddTrack(string title, int rating)
        {
            if (rating >= 0 && rating <= 100)
            {
                Track track = new Track(title, rating);
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{title}    {rating}");
                }
                if (TrackAdded != null)
                {
                    TrackAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Please enter rate between 0 and 100");  
            }
        }

        public override void AddTrack(string title, string rating)
        {
            if (int.TryParse(rating, out int result))
            {
                AddTrack(title, result);
            }
            else
            {
                throw new Exception("enter valid string"); 
            }
        }
        public override void AddTrack(string title, double rating)
        {
            int ratingAsDouble = (int)rating;
            AddTrack(title, ratingAsDouble);
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (line.Length >= 3)
                        {
                            var lastThreeChars = line.Substring(line.Length - 3);
                            lastThreeChars = lastThreeChars.Trim();
                            if (int.TryParse(lastThreeChars, out int rating))
                            {
                                stats.AddGrade(rating);
                            }
                            else
                            {
                                throw new Exception($"I cannot parse a grade from this line: {line}");
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (line.Length >= 3)
                        {
                            var lastThreeChars = line.Substring(line.Length - 3);
                            lastThreeChars = lastThreeChars.Trim();
                            if (int.TryParse(lastThreeChars, out int rating))
                            {
                                stats.AddGrade(rating);
                            }
                            else
                            {
                                throw new Exception($"I cannot parse a grade from this line: {line}");
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            return stats;
        }
        public override void ShowTracks()
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }

                }
            }
        }
    }
}

