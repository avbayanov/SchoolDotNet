using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return (width + height) * 2;
        }

        public override string ToString()
        {
            return "{ Rectangle width: " + width + ", height: " + height + " }";
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

            Rectangle rectangle = (Rectangle) obj;

            return width == rectangle.width && height == rectangle.height;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;

            hash += prime * hash + width.GetHashCode();
            hash += prime * hash + height.GetHashCode();

            return hash;
        }
    }
}