using _053502_Yurev_Lab6.Collections;
using System;

namespace _053502_Yurev_Lab6.Entities
{
    public class Passenger
    {
        private string _name, _surname, _patronymic, _id;
        private MyCustomCollection<Ticket> Tickets;

        public Passenger(string name, string surname, string patronymic, string id)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _id = id;
            Tickets = new MyCustomCollection<Ticket>();
        }
        
        public void BuyTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetPatronymic()
        {
            return _patronymic;
        }
        
        public string GetId()
        {
            return _id;
        }

        public int GetTicketsPrice()
        {
            int totalPrice = 0;
            
            for (int i = 0; i < Tickets.Count; i++)
            {
                totalPrice += Tickets[i].GetPrice();
            }

            return totalPrice;
        }
    }
}