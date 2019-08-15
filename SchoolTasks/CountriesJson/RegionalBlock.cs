using System.Collections.Generic;

namespace CountriesJson
{
    public class RegionalBlock
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public IList<string> OtherAcronyms { get; set; }
        public IList<string> OtherNames { get; set; }
    }
}