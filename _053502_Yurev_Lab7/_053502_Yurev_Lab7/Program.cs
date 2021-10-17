using System;
using _053502_Yurev_Lab7.Entities;

namespace _053502_Yurev_Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int pick = -1;
            Airport airport = new Airport();
            
            while (pick != 0)
            {
                Console.WriteLine("###################################");
                Console.WriteLine("1.Show all tariffs.\n" +
                                  "2.Add new tariff.\n" +
                                  "3.Сheck in for a flight.\n" +
                                  "4.Return ticket.\n" +
                                  "5.View passenger information.\n" +
                                  "6.Get a passenger who has paid a large amount.\n" +
                                  "7.Receive number of passengers who paid more than entered amount.\n" +
                                  "8.Group by tariffs.\n" +
                                  "9.Get an amount spent on each direction.\n" +
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
                        airport.ReturnTicket();
                        break;
                    
                    case 5:
                        airport.ViewPassenger();
                        break;
                    
                    case 6:
                        airport.RichestPassenger();
                        break;
                    
                    case 7:
                        airport.GetPassengerWhoPaidMoreThan();
                        break;
                    
                    case 8:
                        airport.SpentOnDirection();
                        break;

                    case 9:
                        airport.TicketsSold();
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
