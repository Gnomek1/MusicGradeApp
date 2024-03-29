﻿namespace MusicGradeApp
{
    public interface IGenre
    {
        string MusicGenre { get; }
        void AddTrack(string title, int rating);
        void AddTrack(string title, string rating);
        void AddTrack(string title, double rating);
        event GenreBase.AddTrackDelegate TrackAdded;
        Statistics GetStatistics();
    }
}
