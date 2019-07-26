using System;

namespace MultiTable
{
    class MultiTable
    {
        static void Main(string[] args)
        {
            printMultiTable(10, 10);
        }

        private static void printMultiTable(int width, int height)
        {
            int maxNumber = width * height;

            int cellWidth = 1;
            while (maxNumber > 0)
            {
                cellWidth++;
                maxNumber /= 10;
            }

            printHead(width, cellWidth);
            printBody(width, height, cellWidth);
        }

        private static void printHead(int width, int cellWidth)
        {
            Console.Write("{0, " + cellWidth + "}", "");
            Console.Write("|");

            for (int i = 1; i <= width; i++)
            {
                Console.Write("{0, " + cellWidth +"}", i);
            }

            Console.WriteLine();

            for (int i = 0; i < (width + 1) * cellWidth + 1; i++)
            {
                if (i != cellWidth)
                {
                    Console.Write("-");
                } else
                {
                    Console.Write("+");
                }
            }

            Console.WriteLine();
        }

        private static void printBody(int width, int height, int cellWidth)
        {
            for (int i = 1; i <= height; i++)
            {
                Console.Write("{0, " + cellWidth + "}", i);
                Console.Write("|");

                for (int j = 1; j <= width; j++)
                {
                    Console.Write("{0, " + cellWidth + "}", i * j);
                }

                Console.WriteLine();
            }
        }
    }
}