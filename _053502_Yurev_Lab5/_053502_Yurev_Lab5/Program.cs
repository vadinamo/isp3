using System;
using _053502_Yurev_Lab5.Collections;
using _053502_Yurev_Lab5.Entities;

namespace _053502_Yurev_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tariff tariff = new Tariff();
            int pick = -1;

            while (pick != 0)
            {
                Console.WriteLine("1.Add\n2.Remove\n3.Remove current\n4.See all\n0.Exit");
                pick = int.Parse(Console.ReadLine());
                switch (pick)
                {
                    case 1:
                        tariff.AddTariff();
                        break;
                    
                    case 4:
                        tariff.ShowTariffs();
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}