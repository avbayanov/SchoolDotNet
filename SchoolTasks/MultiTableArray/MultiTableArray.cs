using System;

namespace MultiTableArray
{
    class MultiTableArray
    {
        static void Main(string[] args)
        {
            int[,] multiTable = GetMultiTableArray(10, 10);

            PrintTable(multiTable);
        }

        private static void PrintTable(int[,] table)
        {
            string format = "{0, " + 
                            GetCellWidth(table[table.GetLength(0) - 1, table.GetLength(1) - 1]) +
                            "}";

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(format, table[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static int GetCellWidth(int cellData)
        {
            int cellWidth = 1;

            while (cellData > 0)
            {
                cellWidth++;
                cellData /= 10;
            }

            return cellWidth;
        }

        private static int[,] GetMultiTableArray(int height, int width)
        {
            int[,] result = new int[height, width];

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    result[i - 1, j - 1] = i * j;
                }
            }

            return result;
        }
    }
}