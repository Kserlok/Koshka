﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Koshka
{
    class CommandCenter
    {
        public int eat;

        public CommandCenter(CatSmartHouse CatHouse)
        {
            CatSmartHouse = CatHouse;
            WaitCommand();
        }

        public CatSmartHouse CatSmartHouse { get; set; }

        public void WaitCommand()
        {
            string command = "";
            while (command != "exit")
            {
                Console.SetCursorPosition(0, CatSmartHouse.CatsCount + 1);
                command = Console.ReadLine();
                string[] array = command.Split();
                if (array[0] == "store")
                {
                    int smth = Convert.ToInt32(array[2]);
                    CatSmartHouse.FoodResourse += smth;

                }

                if (command == "cls")
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.Clear();
                        Console.Write(i);
                    }
                }
                else if (command == "help")
                {
                    Console.WriteLine("Списки доступных вам команд: \n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Добавить корма в вольер:      store *название корма* *количество корма*");
                    Console.WriteLine("Очистить консоль:             cls");
                    Console.WriteLine("Изменить границу голода:      ChangeHungryLimit *на сколько*");
                    Console.ResetColor();
                }
                if (command == "ChangeHungryLimit")
                {
                    if (array[1] == "+")
                    {
                        int.TryParse(Console.ReadLine(), out eat);
                        eat -= Convert.ToInt32(array[2]);
                    }
                    else if (array[1] == "-")
                    {
                        int.TryParse(Console.ReadLine(), out eat);
                        eat += Convert.ToInt32(array[2]);
                    }
                }
            }
        }
    }
}
