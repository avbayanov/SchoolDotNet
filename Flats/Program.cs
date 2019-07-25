using System;

namespace Flats
{
    class Program
    {
        const int flatsOnLevel = 4;

        static int levels;
        static int entrances;
        static int flat;

        static int flatsInEntrance;
        static int foundEntrance;

        static void Main(string[] args)
        {
            GetUserData();

            if (!IsFlatExists())
            {
                Console.WriteLine("Такой квартиры не существует");
                return;
            }

            Console.WriteLine("Квартира расположена в {0} подъезде, на {1} этаже, {2}",
                GetFoundEntrance(), GetFoundLevel(), GetFlatLocation());
        }

        static void GetUserData()
        {
            Console.Write("Введите число этажей: ");
            levels = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число подъездов: ");
            entrances = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер квартиры: ");
            flat = Convert.ToInt32(Console.ReadLine());
        }

        static bool IsFlatExists()
        {
            flatsInEntrance = flatsOnLevel * levels;

            if (flat < 0 || flat > flatsInEntrance * entrances)
            {
                return false;
            }

            return true;
        }

        static int GetFoundEntrance()
        {
            return foundEntrance = (int)Math.Ceiling((double)flat / flatsInEntrance);
        }

        static int GetFoundLevel()
        {
            return (int)Math.Ceiling((flat - flatsInEntrance * (foundEntrance - 1)) / (double)flatsOnLevel);
        }

        static string GetFlatLocation()
        {
            int positionOnLevel = flat % flatsOnLevel;

            switch (positionOnLevel)
            {
                case 1:
                    return "ближняя слева";
                case 2:
                    return "дальняя слева";
                case 3:
                    return "дальняя справа";
                case 0:
                    return "ближняя справа";
                default:
                    return "невозможно определить расположение";
            }
        }
    }
}
