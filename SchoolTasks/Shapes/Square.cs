using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : IShape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public double GetWidth()
        {
            return side;
        }

        public double GetHeight()
        {
            return side;
        }

        public double GetArea()
        {
            return Math.Pow(side, 2);
        }

        public double GetPerimeter()
        {
            return side * 4;
        }

        public override string ToString()
        {
            return "{ Square side: " + side + " }";
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

            Square square = (Square) obj;

            return side.Equals(square.side);
        }

        public override int GetHashCode()
        {
            int prime = 5;

            return prime * side.GetHashCode();
        }
    }
}