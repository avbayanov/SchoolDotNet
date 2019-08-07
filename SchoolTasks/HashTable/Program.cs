using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> integers = new HashTable<int>(55);
            integers.Add(0);
            integers.Add(30);
            integers.Add(55);
            integers.Add(78);
            integers.Add(99);

            Console.WriteLine("integers: " + String.Join(", ", integers));

            Console.WriteLine("integers.Contains(78) = " + integers.Contains(78));

            Console.WriteLine("removing '55'");
            integers.Remove(55);
            Console.WriteLine("integers: " + String.Join(", ", integers));

            Console.WriteLine("copying integers to array and shifting elements 1 position right");
            int[] array = new int[integers.Count + 1];
            integers.CopyTo(array, 1);
            Console.WriteLine("array: " + String.Join(", ", array));

            Console.WriteLine("clearing integers");
            integers.Clear();
            Console.WriteLine("integers: " + String.Join(", ", integers));
        }
    }
}