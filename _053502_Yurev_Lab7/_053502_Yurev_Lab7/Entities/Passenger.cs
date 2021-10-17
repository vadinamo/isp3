using System.Collections.Generic;

namespace _053502_Yurev_Lab7.Entities
{
    public class Passenger
    {
        private string _name, _surname, _patronymic, _id;
        private List<Ticket> Tickets;

        public Passenger()
        {
            _name = null;
            _surname = null;
            _patronymic = null;
            _id = null;
            Tickets = new List<Ticket>();
        }
        
        public Passenger(string name, string surname, string patronymic, string id)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _id = id;
            Tickets = new List<Ticket>();
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

        public List<Ticket> GetTicketsList()
        {
            return Tickets;
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