using System;
using _053502_Yurev_Lab5.Collections;

namespace _053502_Yurev_Lab5.Entities
{
    public class Tariff
    {
        private string _from, _to;
        private int _price;
        private MyCustomCollection<Tariff> Tariffs = new MyCustomCollection<Tariff>();
        
        public Tariff()
        {
            _from = "";
            _to = "";
            _price = 0;
        }
        
        public Tariff(string from, string to, int price)
        {
            _from = from;
            _to = to;
            _price = price;
        }

        public int IntCheck()   //проверка ввода int
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))//проверка ввода
            {
                Console.WriteLine("Incorrect input!");
            }
            return a;
        } 
        
        public void AddTariff()
        {
            string from, to;
            int price;
            
            Console.WriteLine("###################################\n");
            Console.WriteLine("Enter where the departure is from.");
            from = Console.ReadLine();
            
            Console.WriteLine("Enter where the flight is headed.");
            to = Console.ReadLine();
            
            Console.WriteLine("Enter flight price.");
            price = IntCheck();

            Tariff tariff = new Tariff(from, to, price);
            Tariffs.Add(tariff);
            
            Console.WriteLine("Tariff added successfully.");
            Console.WriteLine("###################################\n");
        }

        public void ShowTariffs()
        {
            for (int i = 0; i < Tariffs.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + Tariffs[i]._from + "\n" + Tariffs[i]._to + "\n" + Tariffs[i]._price);
            }
        }
    }
}