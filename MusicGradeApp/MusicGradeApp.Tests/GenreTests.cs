namespace MusicGradeApp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenCollectRatingsInMemory_thenCorrectResult()
        {
            // arrange
            var genre = new GenreInMemory("Black Metal");
            genre.AddTrack("Mayhem-Frezing Moon",80);
            genre.AddTrack("Mayhem-DeathCrush",70);
            genre.AddTrack("Odraza-Najkrótsza z wiecznoœci",90);
            genre.AddTrack("Odraza-Ja nie st¹d",100);
            genre.AddTrack("Odraza-W godzinie Wilka",40);
            

            // act
            var result = genre.GetStatistics();
            // assert
            Assert.AreEqual(100, result.Max);
            Assert.AreEqual(40, result.Min);
            Assert.AreEqual(76.0f, result.Average);
        }
        
        [Test]
        public void WhenCreateGenreInFile_ThenCreateCorrectTXTFile()
        {
            // Arrange
            string genreName = "BlackMetal";
            string fileName = $"{genreName}rating.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var genre = new GenreInFile(genreName);

            // Act 
            genre.AddTrack("Mayhem-Frezing Moon", 95);
            genre.AddTrack("Mayhem-DeathCrush", 93);
            genre.AddTrack("Odraza-Najkrótsza z wiecznoœci", 99);
            genre.AddTrack("Odraza-Ja nie st¹d", 100);
            genre.AddTrack("Odraza-W godzinie Wilka", 99);

            // Assert 
            bool fileExists = File.Exists(fileName);
            Assert.IsTrue(fileExists, "The file was not created.");

            if (fileExists)
            {
                File.Delete(fileName);
            }

        }
    }
}