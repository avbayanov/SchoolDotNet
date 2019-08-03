using System;

namespace Shapes.Shapes
{
    class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((x1 - x3) * (y2 - y1) - (x1 - x2) * (y3 - y1));
        }

        private static double GetLineLength(double xA, double yA, double xB, double yB)
        {
            return Math.Sqrt(Math.Pow(xB - xA, 2) + Math.Pow(yB - yA, 2));
        }

        public double GetPerimeter()
        {
            return GetLineLength(x1, y1, x2, y2) + GetLineLength(x2, y2, x3, y3) + GetLineLength(x3, y3, x1, y1);
        }

        public override string ToString()
        {
            return "{ Triangle x1: " + x1 + ", y1: " + y1 + ", "
                   + "x2: " + x2 + ", y2: " + y2 + ", "
                   + "x3: " + x3 + ", y3: " + y3 + " }";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle) obj;

            return x1 == triangle.x1 && y1 == triangle.y1
                   && x2 == triangle.x2 && y2 == triangle.y2
                   && x3 == triangle.x3 && y3 == triangle.y3;
        }

        public override int GetHashCode()
        {
            int prime = 9;
            int hash = 1;

            hash += prime * hash + x1.GetHashCode();
            hash += prime * hash + y1.GetHashCode();
            hash += prime * hash + x2.GetHashCode();
            hash += prime * hash + y2.GetHashCode();
            hash += prime * hash + x3.GetHashCode();
            hash += prime * hash + y3.GetHashCode();

            return hash;
        }
    }
}