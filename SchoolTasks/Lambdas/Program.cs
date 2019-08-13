using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Иван", 15),
                new Person("Сергей", 16),
                new Person("Иван", 28),
                new Person("Петр", 35)
            };

            var uniqueNames = persons
                .Select(person => person.Name)
                .Distinct()
                .ToList();
            Console.WriteLine("Имена: " + string.Join(", ", uniqueNames) + ".");

            var averageAgePersonsUnder18 = persons
                .Where(person => person.Age < 18)
                .Average(filteredPerson => filteredPerson.Age);
            Console.WriteLine("Средний возраст людей младше 18: " + averageAgePersonsUnder18);

            var namesWithAverageAge = persons.GroupBy(person => person.Name)
                .ToDictionary(name => name.Key, groupedPersons => groupedPersons
                    .Average(personInGroup => personInGroup.Age));
            Console.WriteLine("Ключи - имена, а значения - средний возраст: " + string.Join(", ", namesWithAverageAge));

            var personsFrom20To45Names = persons
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .OrderByDescending(filteredPerson => filteredPerson.Age)
                .Select(orderedPerson => orderedPerson.Name)
                .ToList();
            Console.WriteLine("Имена людей, возраст которых от 20 до 45, в порядке убывания возраста: " +
                              string.Join(", ", personsFrom20To45Names));

            Console.WriteLine("Введите требуемое количество корней: ");
            var squareRootsCount = Convert.ToInt32(Console.ReadLine());
            PrintSquareRoots(squareRootsCount);

            Console.WriteLine("Введите требуемое количество чисел Фибоначчи: ");
            var fibonacciCount = Convert.ToInt32(Console.ReadLine());
            PrintFibonacci(fibonacciCount);
        }

        public static IEnumerable<double> GetSquareRoots()
        {
            var i = 1;
            while (true)
            {
                yield return Math.Sqrt(i);
                i++;
            }
        }

        public static void PrintSquareRoots(int count)
        {
            var squareRoots = GetSquareRoots()
                .Take(count)
                .ToList();

            Console.WriteLine(string.Join(", ", squareRoots));
        }

        public static IEnumerable<double> GetFibonacci()
        {
            var first = 0;
            var second = 1;

            while (true)
            {
                yield return first;
                var current = first + second;
                first = second;
                second = current;
            }
        }

        public static void PrintFibonacci(int count)
        {
            var fibonacci = GetFibonacci()
                .Take(count)
                .ToList();

            Console.WriteLine(string.Join(", ", fibonacci));
        }
    }
}