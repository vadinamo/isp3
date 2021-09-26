using _053502_Yurev_Lab5.Collections;
using System;

namespace _053502_Yurev_Lab5.Entities
{
    public class Ticket
    {
        private Tariff _tariff;
        private string _id;
        private MyCustomCollection<Ticket> Tickets = new MyCustomCollection<Ticket>();
    }
}