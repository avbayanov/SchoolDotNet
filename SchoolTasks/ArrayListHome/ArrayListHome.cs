using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lines from file:");
            foreach (string line in GetAllLinesFromFile("..\\..\\test1.txt"))
            {
                Console.WriteLine(line);
            }

            List<int> listIntForEvenRemoving = new List<int> {1, 2, 3, 4, 5};
            Console.WriteLine("List with even integers: " + string.Join(", ", listIntForEvenRemoving));

            RemoveEvenIntegers(listIntForEvenRemoving);
            Console.WriteLine("List without even integers: " + string.Join(", ", listIntForEvenRemoving));

            List<int> listIntForDuplicatesRemoving = new List<int> { 1, 1, 2, 2, 5 };
            Console.WriteLine("List with duplicates integers: " + string.Join(", ", listIntForDuplicatesRemoving));
            Console.WriteLine("List without duplicates integers: " + string.Join(", ", GetWithoutDuplicates(listIntForDuplicatesRemoving)));
        }

        private static List<string> GetAllLinesFromFile(string path)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        lines.Add(currentLine);
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }

            return lines;
        }

        private static void RemoveEvenIntegers(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] % 2 == 0)
                {
                    intList.RemoveAt(i);
                    i--;
                }
            }
        }

        private static List<int> GetWithoutDuplicates(List<int> listInt)
        {
            List<int> result = new List<int>();

            foreach (int integer in listInt)
            {
                if (!result.Contains(integer))
                {
                    result.Add(integer);
                }
            }

            return result;
        }
    }
}