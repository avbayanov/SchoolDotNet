using System.Collections.Generic;

namespace CountriesJson
{
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
