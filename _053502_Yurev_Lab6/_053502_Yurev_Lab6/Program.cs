using System;
using _053502_Yurev_Lab6.Entities;

namespace _053502_Yurev_Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Airport airport = new Airport();
            Journal journal = new Journal();
            airport.ticketEvent += Console.WriteLine;
            airport.passengerEvent += journal.AddEvent;
            airport.tariffEvent += journal.AddEvent;
            
            int pick = -1;

            while (pick != 0)
            {
                Console.WriteLine("###################################");
                Console.WriteLine("1.Show all tariffs.\n" +
                                  "2.Add new tariff.\n" +
                                  "3.Сheck in for a flight.\n" +
                                  "4.Return ticket.\n" +
                                  "5.View passenger information.\n" +
                                  "6.Сalculate the cost of tickets sold.\n" +
                                  "7.Show passengers and tariffs events.\n" +
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
                        airport.TicketsSold();
                        break;
                    
                    case 7:
                        journal.ShowEvents();
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