namespace MusicGradeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CWColor(ConsoleColor.DarkGreen, "Welcome in Music Grades App");
            Console.WriteLine("============================");
            bool CloseApp = true;
            string musicGenre = "";

            CWColor(ConsoleColor.DarkYellow, "1-Add track name and rating to program memory and show stats");
            CWColor(ConsoleColor.DarkYellow, "2-Add track name and rating to \"grenre_name\"rating.txt and show stats");
            CWColor(ConsoleColor.DarkYellow, "\"X-Close App\"");
            var userInput = Console.ReadLine().ToUpper();

            while (CloseApp)
            {
                if (userInput == "1")
                {
                    while (musicGenre.Length == 0)
                    {
                        CWColor(ConsoleColor.Green, "Please enter a music genre: ");
                        musicGenre = Console.ReadLine();
                    }

                    GenreInMemory genre = new GenreInMemory(musicGenre);
                    genre.TrackAdded += GenreTrackAdded;
                    string track = "";
                    string rating = "";

                    while (true)
                    {
                        CWColor(ConsoleColor.Green, $"Please enter a track name  (or press 'q' to exit): ");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            track = input;
                            WColor(ConsoleColor.Green, $"Please enter a {track} rating (or press 'q' to exit): ");
                            input = Console.ReadLine();
                            rating = input;
                            try
                            {
                                genre.AddTrack(track, rating);
                            }
                            catch (Exception e)
                            {
                                CWColor(ConsoleColor.Red, $"Exception catched: {e.Message}");
                            }
                        }
                    }

                    Statistics statistics = genre.GetStatistics();
                    ShowStats(statistics);
                    CloseApp = false;
                }
                else if (userInput == "2")
                {
                    while (musicGenre.Length == 0)
                    {
                        Console.Write("Please enter a music genre: ");
                        musicGenre = Console.ReadLine();
                    }
                    GenreInFile genre = new GenreInFile(musicGenre);
                    genre.TrackAdded += GenreTrackAdded;
                    string track = "";
                    string rating = "";

                    while (true)
                    {
                        WColor(ConsoleColor.Green, $"Please enter a track name for {musicGenre} (or press 'q' to exit): ");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            track = input;
                            WColor(ConsoleColor.Green, $"Please enter a {track} rating (or press 'q' to exit): ");
                            input = Console.ReadLine();
                            rating = input;
                            try
                            {
                                genre.AddTrack(track, rating);
                            }
                            catch (Exception e)
                            {
                                WColor(ConsoleColor.Red, $"Exception catched: {e.Message}");
                            }
                        }
                    }
                    Statistics statistics = genre.GetStatistics();
                    ShowStats(statistics);
                    genre.ShowTracks();
                    CloseApp = false;
                }
                else if (userInput == "X")
                {
                    CWColor(ConsoleColor.Magenta, "Good Bye");
                    CloseApp = false;
                }
                else
                {
                    CWColor(ConsoleColor.Magenta, "Please enter a valid option next time");
                    break;
                }
            }
        }

        private static void GenreTrackAdded(object sender, EventArgs args)
        {
            CWColor(ConsoleColor.Cyan, "Track added");
        }

        private static void CWColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void WColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static void ShowStats(Statistics stats)
        {
            Console.WriteLine($"\nmax:{stats.Max}");
            Console.WriteLine($"min:{stats.Min}");
            Console.WriteLine($"avg:{stats.Average} \nList of all tracks:");
        }
        //private static void EnterRating()
    }
}




// powtarzalne elementy dodac do 1 metody
