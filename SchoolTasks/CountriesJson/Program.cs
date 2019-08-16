using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CountriesJson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var reader = new StreamReader("americas.json"))
            {
                var countriesRawData = reader.ReadToEnd();
                var countriesDeserializedData = JsonConvert.DeserializeObject<IList<Country>>(countriesRawData);

                Console.WriteLine("Whole population: " + CountryCollectionUtils.GetWholePopulation(countriesDeserializedData));

                Console.WriteLine();

                var currencies = CountryCollectionUtils.GetAllCurrencies(countriesDeserializedData);
                Console.WriteLine("All currencies:");
                Console.WriteLine(string.Join(Environment.NewLine, currencies));
            }
        }
    }
}
