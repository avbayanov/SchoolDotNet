using System;

namespace MultiTable
{
    class MultiTable
    {
        static void Main(string[] args)
        {
            PrintMultiTable(10, 10);
        }

        private static void PrintMultiTable(int width, int height)
        {
            int maxNumber = width * height;

            int cellWidth = 1;
            while (maxNumber > 0)
            {
                cellWidth++;
                maxNumber /= 10;
            }

            PrintHead(width, cellWidth);
            PrintBody(width, height, cellWidth);
        }

        private static void PrintHead(int width, int cellWidth)
        {
            string format = "{0, " + cellWidth + "}";

            Console.Write(format, "");
            Console.Write("|");

            for (int i = 1; i <= width; i++)
            {
                Console.Write(format, i);
            }

            Console.WriteLine();

            for (int i = 0; i < (width + 1) * cellWidth + 1; i++)
            {
                if (i != cellWidth)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write("+");
                }
            }

            Console.WriteLine();
        }

        private static void PrintBody(int width, int height, int cellWidth)
        {
            string format = "{0, " + cellWidth + "}";

            for (int i = 1; i <= height; i++)
            {
                Console.Write(format, i);
                Console.Write("|");

                for (int j = 1; j <= width; j++)
                {
                    Console.Write(format, i * j);
                }

                Console.WriteLine();
            }
        }
    }
}