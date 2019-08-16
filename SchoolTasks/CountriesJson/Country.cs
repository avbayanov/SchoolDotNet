using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesJson
{
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public IList<Currency> Currencies { get; set; }
    }
}
