using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;

namespace Koshka
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Кокос", new DateTime(2015, 02, 10));
            cat.MakeNoise();
            Console.WriteLine($"Коту по имени {cat.Name} уже {cat.GetAge()} лет");
            // cat.HungryStatus = 500;

            Cat cat2 = new Cat("Фисташка", new DateTime(2019, 11, 1));
            cat2.MakeNoise();
            Console.WriteLine($"Коту по имени {cat2.Name} уже {cat2.GetAge()} лет");

            CatSmartHouse catHouse = new CatSmartHouse(900);
            catHouse.AddCat(cat);
            catHouse.AddCat(cat2);

            Console.ReadLine();
        }
    }
}
