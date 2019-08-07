using System;
using System.Collections.Generic;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> integers = new ArrayList<int>();
            integers.Add(1);
            integers.Add(2);
            integers.Add(3);

            Console.WriteLine("integers: " + String.Join(", ", integers));

            Console.WriteLine("integers.Count = " + integers.Count);
            Console.WriteLine("integers[1] = " + integers[1]);
            Console.WriteLine("integers.IndexOf(3) = " + integers.IndexOf(3));

            Console.WriteLine("inserting '5' to index 1");
            integers.Insert(1, 5);
            Console.WriteLine("integers: " + String.Join(", ", integers));

            Console.WriteLine("removing '1'");
            integers.Remove(1);
            Console.WriteLine("integers: " + String.Join(", ", integers));

            Console.WriteLine("copying integers to array and shifting elements 1 position right");
            int[] array = new int[integers.Count + 1];
            integers.CopyTo(array, 1);
            Console.WriteLine("array: " + String.Join(", ", array));

            ArrayList<int> integers1 = new ArrayList<int>(0);
            integers1.EnsureCapacity(1);
            integers1.Add(1);
            integers1.Add(2);
            integers1.Add(3);
            integers1.TrimToCount();

            Console.WriteLine("integers1: " + String.Join(", ", integers1));
        }
    }
}