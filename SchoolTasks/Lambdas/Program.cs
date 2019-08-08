using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Иван", 15));
            persons.Add(new Person("Сергей", 16));
            persons.Add(new Person("Иван", 28));
            persons.Add(new Person("Петр", 35));

            List<string> uniqueNames = persons
                .Select(person => person.Name)
                .Distinct()
                .ToList();
            Console.WriteLine("Имена:" + string.Join(", ", uniqueNames) + ".");

            double averageAgePersonsUnder18 = persons
                .Select(person => person.Age)
                .Where(age => age < 18)
                .Average();
            Console.WriteLine("Средний возраст людей младше 18: " + averageAgePersonsUnder18);

            Dictionary<string, double> namesWithAverageAge = persons.GroupBy(person => person.Name)
                .ToDictionary(name => name.Key, groupedPersons => groupedPersons
                    .Select(personInGroup => personInGroup.Age)
                    .Average());
            Console.WriteLine("Ключи - имена, а значения - средний возраст: " + string.Join(", ", namesWithAverageAge));

            List<string> personsFrom20To45Names = persons
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .OrderByDescending(filteredPerson => filteredPerson.Age)
                .Select(orderedPerson => orderedPerson.Name)
                .ToList();
            Console.WriteLine("Имена людей, возраст которых от 20 до 45, в порядке убывания возраста: " + string.Join(", ", personsFrom20To45Names));

            Console.WriteLine("Введите требуемое количество корней: ");
            int squareRootsCount = Convert.ToInt32(Console.ReadLine());
            PrintSquareRoots(squareRootsCount);

            Console.WriteLine("Введите требуемое количество чисел Фибоначчи: ");
            int fiboCount = Convert.ToInt32(Console.ReadLine());
            PrintFibonacci(fiboCount);
        }

        public static IEnumerable<double> GetSquareRoots()
        {
            int i = 1;
            while (true)
            {
                yield return Math.Sqrt(i);
                i++;
            }
        }

        public static void PrintSquareRoots(int count)
        {
            List<double> squareRoots = GetSquareRoots()
                .Take(count)
                .ToList();

            Console.WriteLine(string.Join(", ", squareRoots));
        }

        public static IEnumerable<double> GetFibonacci()
        {
            int first = 0;
            int second = 1;

            while (true)
            {
                yield return second;
                int current = first + second;
                first = second;
                second = current;
            }
        }

        public static void PrintFibonacci(int count)
        {
            List<double> fibo = GetFibonacci()
                .Take(count)
                .ToList();

            Console.WriteLine(string.Join(", ", fibo));
        }
    }
}
