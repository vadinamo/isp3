using System;
using _053502_Yurev_Lab6.Collections;

namespace _053502_Yurev_Lab6.Entities
{
    public class Airport
    {
        private MyCustomCollection<Tariff> Tariffs = new MyCustomCollection<Tariff>();
        private MyCustomCollection<Passenger> Passengers = new MyCustomCollection<Passenger>();
        private MyCustomCollection<Ticket> Tickets = new MyCustomCollection<Ticket>();

        public delegate void TariffDelegate(string message);
        public delegate void PassengerDelegate(string message);
        public delegate void TicketDelegate(string message);

        public event TariffDelegate tariffEvent;
        public event PassengerDelegate passengerEvent;
        public event TicketDelegate ticketEvent;

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
            Tariffs.Add(tariff);

            tariffEvent?.Invoke("Tariff added.");
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
            
            for (int i = 0; i < Tariffs.Count; i++)
            {
                Console.WriteLine(i + 1 + ". Departure:" + Tariffs[i].GetDeparture() + "\n   Arrival:" 
                                          + Tariffs[i].GetArrival() + "\n   Price:" + Tariffs[i].GetPrice());
            }
                    
            Console.WriteLine("###################################\n");
        }
        
        public void ShowPassengers() //выводит информацию по всем пасскажирам
        {
            Console.Clear();
            Console.WriteLine("\n###################################");
                    
            if(Passengers.Count == 0)
                Console.WriteLine("There are no passengers here yet.");
            
            for (int i = 0; i < Passengers.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                ShortPassengerInformation(Passengers[i]);
            }
                    
            Console.WriteLine("###################################\n");
        }

        public void FullPassengerInformation(Passenger passenger) // полная информация по пассажиру
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

        public void ShortPassengerInformation(Passenger passenger) //короткая информация по пассажиру 
        {
            Console.WriteLine(passenger.GetSurname() + " " +
                              passenger.GetName()[0] + ". " + 
                              passenger.GetId());
        }
        
        public void CheckIn()
        {
            Console.Clear();
            Console.WriteLine("###################################");
            Console.WriteLine("List of tariffs:");
            ShowTariffs();

            if (Tariffs.Count == 0)
                return;
            
            Console.WriteLine("Сhoose the one you want.");
            int pick = -1;
            
            pick = IntCheck();
            pick--;
            
            if(Tariffs[pick] == null)
            {
                return;
            }

            Tariff tariff = Tariffs[pick];
                    
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
                passengerEvent?.Invoke("Passenger added.");
            }

            else
            {
                Ticket ticket = new Ticket(tariff, Passengers[i]);
                Passengers[i].BuyTicket(ticket);
                Tickets.Add(ticket);
            }

            Console.Clear();
            Console.WriteLine("###################################");
            ticketEvent?.Invoke("Passenger (ID: " + Passengers[i].GetId() + ") checked in.");
            Console.WriteLine("Registration completed successfully.");
            Console.WriteLine("###################################\n");
        }
        
        public void ViewPassenger()
        {
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
            int totalCount = 0;
            
            for (int i = 0; i < Tickets.Count; i++)
            {
                totalCount += Tickets[i].GetPrice();
            }
            
            Console.Clear();
            Console.WriteLine("###################################");
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

                for (int i = 0; i < Tickets.Count; i++)
                {
                    if (Tickets[i].GetPassenger().GetId().Equals(id))
                    {
                        Console.WriteLine("Ticket №" + (i + 1) + 
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
                
                ticketEvent?.Invoke("Passenger (ID:" + id + ") returned the ticket.");
                Console.Clear();
                Console.WriteLine("###################################");
                Console.WriteLine("Ticket returned successfully!");
                Console.WriteLine("###################################\n");
            }
        }
    }
}
            