using System.IO;

namespace Excel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var persons = new Person[]
            {
                new Person("FirstName1", "LastName1", 1),
                new Person("FirstName2", "LastName2", 2),
                new Person("FirstName3", "LastName3", 3),
                new Person("FirstName4", "LastName4", 4),
                new Person("FirstName5", "LastName5", 5),
                new Person("FirstName6", "LastName6", 6)
            };

            var outputFile = new FileInfo("output.xlsx");

            persons.WriteToSpreadsheet(outputFile);
        }
    }
}
