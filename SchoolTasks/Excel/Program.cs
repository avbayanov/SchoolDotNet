using System.IO;

namespace Excel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var persons = new Person[]
            {
                new Person {FirstName = "FirstName1", LastName = "LastName1", Age = 1},
                new Person {FirstName = "FirstName2", LastName = "LastName2", Age = 2},
                new Person {FirstName = "FirstName3", LastName = "LastName3", Age = 3},
                new Person {FirstName = "FirstName4", LastName = "LastName4", Age = 4},
                new Person {FirstName = "FirstName5", LastName = "LastName5", Age = 5},
                new Person {FirstName = "FirstName6", LastName = "LastName6", Age = 6}
            };

            var outputFile = new FileInfo("output.xlsx");

            persons.WriteToSpreadsheet(outputFile);
        }
    }
}