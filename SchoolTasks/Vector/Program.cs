using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1);
            vector1.SetComponent(0, 1);
            Console.WriteLine("vector1.GetComponent(0) = " + vector1.GetComponent(0));

            double[] doubles = {1, 2, 3, 4, 5};
            Vector vector2 = new Vector(doubles);
            Console.WriteLine("vector2 = " + vector2);

            Console.WriteLine("Length of " + vector2 + " is " + vector2.GetLength());

            Vector vector3 = new Vector(2, doubles);
            Console.WriteLine("vector3 = " + vector3);

            Console.WriteLine(vector2 + " + " + vector3 + " = " + Vector.Add(vector2, vector3));
            Console.WriteLine(vector2 + " - " + vector3 + " = " + Vector.Subtract(vector2, vector3));

            double multiplier = 5;
            Console.Write(vector2 + " * " + multiplier + " = ");
            vector2.MultiplyByScalar(5);
            Console.WriteLine(vector2);

            Vector vector4 = new Vector(vector2);
            vector4.Reverse();
            Console.WriteLine("Reverted " + vector2 + " is " + vector4);

            Console.WriteLine("Scalar product of " + vector2 + " and " + vector3 + " is "
                              + Vector.ScalarProduct(vector2, vector3));
        }
    }
}
