using System;

namespace Range
{
    class Program
    {

        static void Main(string[] args)
        {
            Range range = new Range(10, 20);

            Console.WriteLine("length of range [10, 20]: " + range.GetLength());

            CheckForInsideRangeAndPrint(range, 20);
        }

        static void CheckForInsideRangeAndPrint(Range range, double input)
        {
            Console.WriteLine(input + " is " + (range.IsInside(input) ? "inside" : "outside") + " of range");
        }
    }
}
