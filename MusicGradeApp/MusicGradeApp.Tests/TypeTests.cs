namespace MusicGradeApp.Tests
{
    internal class TypeTests
    {
        [Test]
        public void WhenGenreReturnsDiffrentObjects_thenCorrectResult()
        {
            var g1 = new GenreInMemory("BM");
            var g2 = new GenreInMemory("BM");
            
            Assert.AreNotSame(g1,g2);
            Assert.False(g1.Equals(g2));

        }
    }
}
