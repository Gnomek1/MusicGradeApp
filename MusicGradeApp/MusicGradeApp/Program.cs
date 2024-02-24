namespace MusicGradeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Genre genre = new Genre("Black metal");
            genre.AddTrack("mayhem", 100);
            genre.AddTrack("mayhe", 100);
            genre.AddTrack("mayh", 100);
            genre.AddTrack("may", 100);
            genre.AddTrack("ma", 100);
            genre.AddTrack("okoko", "50");

            foreach (var item in genre.tracks)
            {
                Console.WriteLine($"{item.Title}    ,   {item.Rating}");
            }

        }
    }
}
