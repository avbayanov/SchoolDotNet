using System;

namespace Range
{
    class Range
    {
        private double from;
        private double to;

        public Range(int from, int to)
        {
            if (from < to)
            {
                this.from = from;
                this.to = to;
            }
            else
            {
                this.from = to;
                this.to = from;
            }
        }

        public double GetLength()
        {
            return to - from;
        }

        public bool IsInside(double input)
        {
            return input >= from && input <= to;
        }
    }
}
