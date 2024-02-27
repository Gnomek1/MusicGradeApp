namespace MusicGradeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome in Music Grades App");
            //Console.WriteLine("============================");

            //string musicGenre = "";
            //while (musicGenre.Length == 0)
            //{
            //    Console.Write("Please enter a music genre: ");
            //    musicGenre = Console.ReadLine();
            //}
            //GenreInMemory genre = new GenreInMemory(musicGenre);

            //string track = "";
            //string rating = "";

            //while (true)
            //{
            //    Console.Write($"Please enter a track name for {musicGenre} (or press 'q' to exit): ");
            //    var input = Console.ReadLine();
            //    if (input.ToLower() == "q")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        track = input;
            //        Console.Write($"Please enter a {track} rating (or press 'q' to exit): ");
            //        input = Console.ReadLine();
            //        rating = input;
            //        genre.AddTrack(track, rating);

            //    }
            //}
            //genre.ShowTracks();
            GenreInFile genre = new GenreInFile("ok");
            genre.AddTrack("ok", 80);

            Statistics statistics = new Statistics();
            
            Console.WriteLine($"{statistics.Max}");
            Console.WriteLine($"{statistics.Min}");
            Console.WriteLine($"{statistics.Average}");


        }
    }
}
