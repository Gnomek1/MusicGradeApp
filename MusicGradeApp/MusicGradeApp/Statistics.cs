﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Max  = float.MinValue;
            Min = float.MaxValue;
        }

        public void AddGrade(float rating)
        {
            Count++;
            Sum += rating;
            Min = Math.Min(rating, Min);
            Max = Math.Max(rating, Max);
        }


    }
}
