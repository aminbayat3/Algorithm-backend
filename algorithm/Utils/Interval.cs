using System;
using System.Collections.Generic;


namespace algorithm.Utils
{
    public class Interval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Energy { get; set; }

        public Interval(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            Energy = 0; // Default energy value
        }
    }
}
