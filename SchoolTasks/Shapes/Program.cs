using System;
using System.Collections;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape square1 = new Square(10);
            IShape square2 = new Square(20);

            IShape rectangle1 = new Rectangle(10, 10);
            IShape rectangle2 = new Rectangle(20, 20);

            IShape triangle1 = new Triangle(10, 20, 20, 20, 30, 30);
            IShape triangle2 = new Triangle(10, 10, 10, 30, 30, 30);

            IShape circle1 = new Circle(10);
            IShape circle2 = new Circle(20);

            IShape[] shapes = {square1, square2, rectangle1, rectangle2, triangle1, triangle2, circle1, circle2};

            Array.Sort(shapes, new AreaComparer());
            Console.WriteLine("Фигура с максимальной площадью: " + shapes[0]);

            Array.Sort(shapes, new PerimeterComparer());
            Console.WriteLine("Фигура со вторым по размеру периметром: " + shapes[1]);
        }
    }
}