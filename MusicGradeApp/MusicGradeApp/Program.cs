namespace MusicGradeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome in Music Grades App");
            Console.WriteLine("============================");
            Console.ResetColor();
            bool CloseApp = true;
            string musicGenre = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1-Add track name and rating to program memory and show stats");
            Console.WriteLine("2-Add track name and rating to \"grenre_name\"rating.txt and show stats");
            Console.WriteLine("X-Close App");
            var userInput = Console.ReadLine().ToUpper();
            Console.ResetColor();
            while (CloseApp)
            {
                if (userInput == "1")
                {
                    while (musicGenre.Length == 0)
                    {
                        Console.Write("Please enter a music genre: ");
                        musicGenre = Console.ReadLine();
                    }
                    GenreInMemory genre = new GenreInMemory(musicGenre);

                    string track = "";
                    string rating = "";

                    while (true)
                    {
                        Console.Write($"Please enter a track name for {musicGenre} (or press 'q' to exit): ");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            track = input;
                            Console.Write($"Please enter a {track} rating (or press 'q' to exit): ");
                            input = Console.ReadLine();
                            rating = input;
                            genre.AddTrack(track, rating);

                        }
                    }
                    Statistics statistics = genre.GetStatistics();
                    Console.WriteLine($"max:{statistics.Max}");
                    Console.WriteLine($"min:{statistics.Min}");
                    Console.WriteLine($"avg:{statistics.Average}");
                    genre.ShowTracks();
                    CloseApp=false;
                }
                else if (userInput == "2")
                {
                        while (musicGenre.Length == 0)
                        {
                            Console.Write("Please enter a music genre: ");
                            musicGenre = Console.ReadLine();
                        }
                        GenreInMemory genre = new GenreInMemory(musicGenre);

                        string track = "";
                        string rating = "";

                        while (true)
                        {
                            Console.Write($"Please enter a track name for {musicGenre} (or press 'q' to exit): ");
                            var input = Console.ReadLine();
                            if (input.ToLower() == "q")
                            {
                                break;
                            }
                            else
                            {
                                track = input;
                                Console.Write($"Please enter a {track} rating (or press 'q' to exit): ");
                                input = Console.ReadLine();
                                rating = input;
                                genre.AddTrack(track, rating);

                            }
                        }
                        Statistics statistics = genre.GetStatistics();
                        Console.WriteLine($"max:{statistics.Max}");
                        Console.WriteLine($"min:{statistics.Min}");
                        Console.WriteLine($"avg:{statistics.Average}");
                        genre.ShowTracks();
                    CloseApp = false;
                }
                else if (userInput == "X")
                {
                    Console.WriteLine("Good Bye");
                    CloseApp = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                    continue;
                }



            }
        }
    }
}
