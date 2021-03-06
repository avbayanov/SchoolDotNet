﻿using System;

namespace Range
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(int from, int to)
        {
            if (from < to)
            {
                this.From = from;
                this.To = to;
            }
            else
            {
                this.From = to;
                this.To = from;
            }
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double input)
        {
            return input >= From && input <= To;
        }
    }
}