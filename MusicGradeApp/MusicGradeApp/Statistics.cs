namespace MusicGradeApp
{
    public class Statistics
    {
        public float Max { get; private set; }
        public float Min { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0.0f;
            Max = int.MinValue;
            Min = int.MaxValue;
        }

        public void AddGrade(int rating)
        {
            Count++;
            Sum += rating;
            Min = Math.Min(rating, Min);
            Max = Math.Max(rating, Max);
        }


    }
}
