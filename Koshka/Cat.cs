
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Koshka
{
    class Cat
    {
        sbyte _hungryStatus = 100;
        public event EventHandler HungryStatusChanged;
        public Cat(string name, DateTime birthday)
        {
            Name = name;
            BirthDay = birthday;
            Task.Run(LifeCircle);
        }
        public string Name
        {
            get;
            set;
        }
        public void MakeNoise()
        {
            Console.WriteLine($"{Name } мяукает");
        }
        public DateTime BirthDay
        {
            get; set;
        }

        public int GetAge()
        {
            return (DateTime.Today - BirthDay).Days / 365;
        }

        public sbyte HungryStatus
        {
            get { return _hungryStatus; }
            set
            {
                sbyte Status2 = 0;
                if (value < 0)
                    Status2 = 0;
                else if (value > 100)
                    Status2 = 100;
                else
                    Status2 = value;
                bool invoke = _hungryStatus > Status2;
                _hungryStatus = Status2;
                if (invoke)
                    HungryStatusChanged?.Invoke(this, null);
            }
        }
        public void Feed(sbyte needFood)
        {
            HungryStatus += needFood;
        }

        public string GetStatus(string color)
        {
            string name = Name;
            string age = Convert.ToString(GetAge());
            string status = Convert.ToString(HungryStatus);
            if (HungryStatus < 10)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkRed));
            }
            else if (HungryStatus >= 10 && HungryStatus <= 40)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Red));
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkYellow));
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Green));
            }
            return $"{color} Имя: {name}, Возраст: {age}, Статус: {status}";
        }

        public async Task LifeCircle()
        {
            await Task.Delay(200);
            HungryStatus -= 10;
            await LifeCircle(); 
        }
    }
}


