using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CountriesJson
{
    public static class CountryCollectionUtils
    {
        public static int GetWholePopulation(IEnumerable<Country> countries)
        {
            return countries.Sum(country => country.Population);
        }

        public static IList<Currency> GetAllCurrencies(IEnumerable<Country> countries)
        {
//            var currencies = new List<Currency>();

            return countries.SelectMany(country => country.Currencies).ToList();
        }
    }
}