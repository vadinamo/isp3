using System;
using _053502_Yurev_Lab5.Collections;
using _053502_Yurev_Lab5.Entities;

namespace _053502_Yurev_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport();
            int pick = -1;
            Console.Clear();
            
            while (pick != 0)
            {
                Console.WriteLine("###################################");
                Console.WriteLine("1.Show all tariffs.\n" +
                                  "2.Add new tariff.\n" +
                                  "3.Сheck in for a flight.\n" +
                                  "4.View passenger information.\n" +
                                  "5.Сalculate the cost of tickets sold.\n" +
                                  "0.Exit.");
                Console.WriteLine("###################################\n");
                
                pick = airport.IntCheck();
                switch (pick)
                {
                    case 1:
                        airport.ShowTariffs();
                        break;
                    
                    case 2:
                        airport.AddTariff();
                        break;
                        
                    case 3:
                        airport.CheckIn();
                        break;
                    
                    case 4:
                        airport.ViewPassenger();
                        break;
                    
                    case 5:
                        airport.TicketsSold();
                        break;
                    
                    default:
                        break;
                }

                if (pick != 0)
                {
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}