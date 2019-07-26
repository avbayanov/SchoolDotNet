using System;

namespace Flats
{
    class Program
    {
        private const int flatsOnLevel = 4;

        private static int levels;
        private static int entrances;
        private static int flat;

        private static int flatsInEntrance;
        private static int foundEntrance;
        private static int foundLevel;
        private static string onLevelLocation;

        static void Main(string[] args)
        {
            GetUserData();

            if (!CalculateLocation())
            {
                Console.WriteLine("Такой квартиры не существует");
                return;
            }

            Console.WriteLine("Квартира расположена в {0} подъезде, на {1} этаже, {2}",
                foundEntrance, foundLevel, onLevelLocation);
        }

        private static void GetUserData()
        {
            Console.Write("Введите число этажей: ");
            levels = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число подъездов: ");
            entrances = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер квартиры: ");
            flat = Convert.ToInt32(Console.ReadLine());
        }

        private static bool CalculateLocation()
        {
            flatsInEntrance = flatsOnLevel * levels;

            if (flat < 0 || flat > flatsInEntrance * entrances)
            {
                return false;
            }

            CalculateFoundEntrance();
            CalculateFoundLevel();
            CalculateOnLevelLocation();

            return true;
        }

        private static void CalculateFoundEntrance()
        {
            foundEntrance = (int)Math.Ceiling((double)flat / flatsInEntrance);
        }

        private static void CalculateFoundLevel()
        {
            foundLevel = (int)Math.Ceiling((flat - flatsInEntrance * (foundEntrance - 1)) / (double)flatsOnLevel);
        }

        private static void CalculateOnLevelLocation()
        {
            int positionOnLevel = flat % flatsOnLevel;

            switch (positionOnLevel)
            {
                case 1:
                    onLevelLocation = "ближняя слева";
                    break;
                case 2:
                    onLevelLocation = "дальняя слева";
                    break;
                case 3:
                    onLevelLocation = "дальняя справа";
                    break;
                case 0:
                    onLevelLocation = "ближняя справа";
                    break;
                default:
                    onLevelLocation = "невозможно определить расположение";
                    break;
            }
        }
    }
}
