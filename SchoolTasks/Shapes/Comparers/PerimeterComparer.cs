using System.Collections.Generic;

namespace Shapes.Comparers
{
    public class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return x.GetPerimeter().CompareTo(y.GetPerimeter());
        }
    }
}