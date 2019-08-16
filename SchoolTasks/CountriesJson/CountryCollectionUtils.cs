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
            return countries.SelectMany(country => country.Currencies)
                .GroupBy(currency => currency.Code)
                .Select(currencies => currencies.First())
                .ToList();
        }
    }
}