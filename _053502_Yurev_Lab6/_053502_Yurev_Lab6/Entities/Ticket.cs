using _053502_Yurev_Lab6.Collections;
using System;

namespace _053502_Yurev_Lab6.Entities
{
    public class Ticket
    {
        private Tariff _tariff;
        private Passenger _passenger;

        public Ticket(Tariff tariff, Passenger passenger)
        {
            _tariff = tariff;
            _passenger = passenger;
        }

        public int GetPrice()
        {
            return _tariff.GetPrice();
        }

        public Passenger GetPassenger()
        {
            return _passenger;
        }

        public Tariff GetTariff()
        {
            return _tariff;
        }
    }
}