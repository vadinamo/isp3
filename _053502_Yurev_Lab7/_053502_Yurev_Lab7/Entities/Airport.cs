using System;
using System.Collections.Generic;
using System.Linq;

namespace _053502_Yurev_Lab7.Entities
{
    public class Airport
    {
        private Dictionary<string, Tariff> Tariffs = new Dictionary<string, Tariff>();
        private List<Passenger> Passengers = new List<Passenger>();
        private List<Ticket> Tickets = new List<Ticket>();
        
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
            Console.Clear();
            string from, to;
            int price;
                    
            Console.WriteLine("\n###################################");
            Console.WriteLine("Enter where the departure is from.");
            from = Console.ReadLine();
                    
            Console.WriteLine("Enter where the flight is headed.");
            to = Console.ReadLine();
                    
            Console.WriteLine("Enter flight price.");
            price = IntCheck();
        
            Tariff tariff = new Tariff(from, to, price);
            Tariffs.Add(tariff.GetDeparture() + "—" + tariff.GetArrival(),tariff);
            
            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("Tariff added successfully.");
            Console.WriteLine("###################################\n");
        }

        public void ShowTariffs()
        {
            Console.Clear();
            Console.WriteLine("\n###################################");

            if(Tariffs.Count == 0)
                Console.WriteLine("There are no tariffs here yet.");

            var sortedTariffs = Tariffs.OrderBy(t => t.Value.GetPrice()).ToDictionary(t => t.Key, t => t.Value);
            Tariffs = sortedTariffs;

            int i = 1;
            foreach (KeyValuePair<string, Tariff> t in Tariffs)
            {
                Console.WriteLine(i++ + ". " + t.Key + ", " + t.Value.GetPrice());
            }
                    
            Console.WriteLine("###################################\n");
        }

        public void ShowPassengers()
        {
            Console.Clear();
            Console.WriteLine("\n###################################");
                    
            if(Passengers.Count == 0)
                Console.WriteLine("There are no passengers here yet.");

            else
            {
                int i = 1;
                foreach (Passenger passenger in Passengers)
                {
                    Console.Write(i++ + ". ");
                    ShortPassengerInformation(passenger);
                }
            }

            Console.WriteLine("###################################\n");
        }

        public void ShortPassengerInformation(Passenger passenger)
        {
            Console.WriteLine(passenger.GetSurname() + " " +
                              passenger.GetName()[0] + ". " + 
                              passenger.GetId());
        }

        public void FullPassengerInformation(Passenger passenger)
        {
            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("Name: " + passenger.GetName()+
                              "\nSurname: " + passenger.GetSurname() +
                              "\nPatronymic: " + passenger.GetPatronymic() +
                              "\nID: " + passenger.GetId() +
                              "\nTotal tickets purchased for the amount of: " + passenger.GetTicketsPrice() + "$");
            Console.WriteLine("###################################\n");
        }

        public void CheckIn()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            
            bool exitsts = false;
            string pickedTariff = null;

            while (!exitsts)
            {
                Console.WriteLine("List of tariffs:");
                ShowTariffs();

                if (Tariffs.Count == 0)
                    return;
            
                Console.WriteLine("Enter departure.");
                String departure = Console.ReadLine();
                Console.WriteLine("Enter arrival.");
                String arrival = Console.ReadLine();

                pickedTariff = departure + "—" + arrival;

                foreach (KeyValuePair<string, Tariff> t in Tariffs)
                {
                    if (t.Key == pickedTariff)
                    {
                        exitsts = true;
                    }
                }
            }
            
            Tariff tariff = Tariffs[pickedTariff];
                    
            Console.WriteLine("\n###################################");
            
            Console.WriteLine("Enter passenger id.");
            String id = Console.ReadLine();
            bool isNew = true;
            int i = 0;
            
            for (i = 0; i < Passengers.Count; i++)
            {
                if (Passengers[i].GetId().Equals(id))
                {
                    ShortPassengerInformation(Passengers[i]);
                    isNew = false;
                    break;
                }
            }
            
            if (isNew)
            {
                Console.WriteLine("Enter passenger name.");
                String name = Console.ReadLine();

                Console.WriteLine("Enter passenger surname.");
                String surname = Console.ReadLine();

                Console.WriteLine("Enter passenger patronymic.");
                String patronymic = Console.ReadLine();
                
                Passenger passenger = new Passenger(name, surname, patronymic, id);
                Ticket ticket = new Ticket(tariff, passenger);
                passenger.BuyTicket(ticket);
                Tickets.Add(ticket);
                Passengers.Add(passenger);
            }

            else
            {
                Ticket ticket = new Ticket(tariff, Passengers[i]);
                Passengers[i].BuyTicket(ticket);
                Tickets.Add(ticket);
            }

            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("Registration completed successfully.");
            Console.WriteLine("###################################\n");
        }

        public void ViewPassenger()
        {
            Console.Clear();
            Console.WriteLine("\n###################################");
            ShowPassengers();

            if (Passengers.Count != 0)
            {
                Console.WriteLine("Enter ID to see information.");
                string id = Console.ReadLine();

                for (int i = 0; i < Passengers.Count; i++)
                {
                    if (Passengers[i].GetId().Equals(id))
                    {
                        FullPassengerInformation(Passengers[i]);
                        break;
                    }

                    if (i == Passengers.Count - 1)
                    {
                        Console.WriteLine("Incorrect ID input!");
                        Console.ReadKey();
                        ViewPassenger();
                    }
                }
            }
        }

        public void TicketsSold()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            int totalCount = 0;
            
            for (int i = 0; i < Tickets.Count; i++)
            {
                totalCount += Tickets[i].GetPrice();
            }
            
            Console.WriteLine("Total tickets sold is: " + (Tickets.Count)+ 
                              "\nTotal recieved: " + totalCount + "$");
            Console.WriteLine("###################################\n");
        }

        public void ReturnTicket()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            ShowPassengers();

            if (Passengers.Count != 0)
            {
                Console.WriteLine("Enter ID to see all passengers tickets.");
                string id = Console.ReadLine();
                bool noTickets = true;
                int i = 1;

                foreach(Ticket ticket in Tickets)
                {
                    if (ticket.GetPassenger().GetId().Equals(id))
                    {
                        Console.WriteLine("Ticket №" + i++ + 
                                          "\nDeparture: " + Tickets[i].GetTariff().GetDeparture() +
                                          "\nArrival: " + Tickets[i].GetTariff().GetArrival() + "\n");
                        noTickets = false;
                    }
                }

                if (noTickets)
                {
                    Console.Clear();
                    Console.WriteLine("###################################");
                    Console.WriteLine("There is no tickets purchased yet.\n");
                    Console.WriteLine("###################################\n");
                    return;
                }
                
                Console.WriteLine("Enter ticket number.");
                int pick = -1;
            
                pick = IntCheck();
                pick--;
            
                if(Tickets[pick] == null)
                {
                    return;
                }
                
                Tickets.Remove(Tickets[pick]);
                
                Console.Clear();
                Console.WriteLine("###################################");
                Console.WriteLine("Ticket returned successfully!");
                Console.WriteLine("###################################\n");
            }
        }

        public void RichestPassenger()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            List<Passenger> richestPassenger = Passengers.OrderBy(p => p.GetTicketsPrice()).ToList();
            FullPassengerInformation(richestPassenger[richestPassenger.Count - 1]);
        }

        public void GetPassengerWhoPaidMoreThan()
        {
            Console.Clear();
            Console.WriteLine("###################################");

            if (Passengers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("###################################\n" +
                                  "There is no passengers yet.\n" +
                                  "###################################\n");
                return;
            }

                Console.WriteLine("Enter the amount.");
            int amount = IntCheck();
            List<Passenger> passengersList = new List<Passenger>();
            
            foreach (Passenger p in Passengers)
            {
                if(p.GetTicketsPrice() > amount)
                    passengersList.Add(p);
            }

            Console.WriteLine($"Total number of passengers who paid more than {amount}$: " +
            Passengers.Aggregate(0, (n, p) => p.GetTicketsPrice() > amount ? n + 1 : n));
            Console.WriteLine("###################################\n");
        }

        public void SpentOnDirection()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            
            ShowPassengers();
            Passenger passenger = new Passenger();
            
            if (Passengers.Count != 0)
            {
                Console.WriteLine("Enter ID to see information.");
                string id = Console.ReadLine();

                for (int i = 0; i < Passengers.Count; i++)
                {
                    if (Passengers[i].GetId().Equals(id))
                    {
                        passenger = Passengers[i];
                        break;
                    }

                    if (i == Passengers.Count - 1)
                    {
                        Console.WriteLine("Incorrect ID input!");
                        Console.ReadKey();
                        SpentOnDirection();
                    }
                }
            }
            
            Console.Clear();
            Console.WriteLine("###################################");

            var directionGroups =
                from ticket in passenger.GetTicketsList()
                group ticket by ticket.GetTariff();
                
            foreach (var g in directionGroups)
            {
                Console.WriteLine("Total spent on " + g.Key.GetDeparture() + "—" + g.Key.GetArrival() + ": " + g.Count() * g.Key.GetPrice() + "$");
                
            }
            Console.WriteLine("###################################\n");
        }
    }
}