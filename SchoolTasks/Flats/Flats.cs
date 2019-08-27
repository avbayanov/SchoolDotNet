using System;

namespace Flats
{
    class Flats
    {
        static void Main(string[] args)
        {
            const int flatsOnLevel = 4;

            Console.Write("Введите число этажей: ");
            int levelsCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число подъездов: ");
            int entrancesCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер квартиры: ");
            int desiredFlat = Convert.ToInt32(Console.ReadLine());

            int flatsInEntrance = flatsOnLevel * levelsCount;

            if (!IsFlatExists(desiredFlat, flatsInEntrance, entrancesCount))
            {
                Console.WriteLine("Такой квартиры не существует");
                return;
            }

            int foundEntrance = GetFoundEntrance(desiredFlat, flatsInEntrance);

            Console.WriteLine("Квартира расположена в {0} подъезде, на {1} этаже, {2}",
                foundEntrance, GetFoundLevel(desiredFlat, flatsInEntrance, flatsOnLevel, foundEntrance),
                GetOnLevelLocation(desiredFlat, flatsOnLevel));
        }

        private static bool IsFlatExists(int desiredFlat, int flatsInEntrance, int entrances)
        {
            return desiredFlat > 0 && desiredFlat <= flatsInEntrance * entrances;
        }

        private static int GetFoundEntrance(int desiredFlat, int flatsInEntrance)
        {
            return (int) Math.Ceiling((double) desiredFlat / flatsInEntrance);
        }

        private static int GetFoundLevel(int desiredFlat, int flatsInEntrance, int flatsOnLevel, int foundEntrance)
        {
            return (int) Math.Ceiling((desiredFlat - flatsInEntrance * (foundEntrance - 1)) / (double) flatsOnLevel);
        }

        private static string GetOnLevelLocation(int desiredFlat, int flatsOnLevel)
        {
            int positionOnLevel = desiredFlat % flatsOnLevel;

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