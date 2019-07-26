using System;

namespace Palindrome
{
    class Palindrome
    {
        static void Main(string[] args)
        {
            Console.Write("введите строку: ");

            string input = Console.ReadLine();

            Console.WriteLine("это " + (IsPalindrome(input) ? "" : "не") + " палиндром");
        }

        private static bool IsPalindrome(string input)
        {
            for (int leftIndex = 0, rightIndex = input.Length - 1; leftIndex <= rightIndex; leftIndex++, rightIndex--)
            {
                while (leftIndex < input.Length && char.IsWhiteSpace(input[leftIndex]))
                {
                    leftIndex++;
                }

                while (rightIndex >= 0 && char.IsWhiteSpace(input[rightIndex]))
                {
                    rightIndex--;
                }

                if (leftIndex < input.Length && rightIndex >= 0)
                {
                    if (char.ToLower(input[leftIndex]) != char.ToLower(input[rightIndex]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}