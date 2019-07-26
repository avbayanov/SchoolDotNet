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
            double epsilon = 1.0e-10;

            if ((from - epsilon <= input) && (to + epsilon >= input))
            {
                return true;
            }

            return false;
        }
    }
}
