using System;
using System.Collections.Generic;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> newInts = new ArrayList<int> {1, 2, 3};
            Console.WriteLine(newInts);
        }
    }
}
