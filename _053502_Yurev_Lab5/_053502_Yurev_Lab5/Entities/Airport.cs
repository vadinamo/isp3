using System;
using System.Diagnostics;
using _053502_Yurev_Lab5.Collections;

namespace _053502_Yurev_Lab5.Entities
{
    public class Airport
    {
        private MyCustomCollection<Tariff> Tariffs = new MyCustomCollection<Tariff>();
        private MyCustomCollection<Passenger> Passengers = new MyCustomCollection<Passenger>();
        private MyCustomCollection<Ticket> Tickets = new MyCustomCollection<Ticket>(); 
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
            Console.WriteLine("List of tariffs:");
            ShowTariffs();

            if (Tariffs.Count == 0)
                return;
            
            Console.WriteLine("Сhoose the one you want.");
            int pick = IntCheck();
            pick--;
        
            if (pick < 0 || pick >= Tariffs.Count)
            {
                Console.WriteLine("Wrong number.");
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
            }

            else
            {
                Ticket ticket = new Ticket(tariff, Passengers[i]);
                Passengers[i].BuyTicket(ticket);
                Tickets.Add(ticket);
            }

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
    }
}