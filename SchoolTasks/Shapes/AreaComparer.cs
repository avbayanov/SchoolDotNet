using System.Collections.Generic;

namespace Shapes
{
    public class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return x.GetArea().CompareTo(y.GetArea());
        }
    }
}