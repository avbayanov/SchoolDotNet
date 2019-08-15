using System.Text;

namespace CountriesJson
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("{ Code: '");
            stringBuilder.Append(Code);

            stringBuilder.Append("', Name: '");
            stringBuilder.Append(Name);

            stringBuilder.Append("', Symbol: '");
            stringBuilder.Append(Symbol);

            stringBuilder.Append("' }");

            return stringBuilder.ToString();
        }
    }
}