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
            }
            else
            {
                Console.WriteLine("Please enter rate between 0 and 100");  //add exceptions
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
                Console.WriteLine("enter valid string"); //add exceptions
            }
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
                                Console.WriteLine($"Nie udało się sparsować oceny z linii: {line}");
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
                                Console.WriteLine($"Nie udało się sparsować oceny z linii: {line}");
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
