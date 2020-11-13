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

            Cat cat2 = new Cat("Фисташка", new DateTime(2019, 11, 1));
            cat2.MakeNoise();

            CatSmartHouse catHouse = new CatSmartHouse(900);
            catHouse.AddCat(cat);
            catHouse.AddCat(cat2);

            CommandCenter CC = new CommandCenter(catHouse);
        }
    }
}
