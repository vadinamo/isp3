using _053502_Yurev_Lab5.Collections;
using System;

namespace _053502_Yurev_Lab5.Entities
{
    public class Passenger
    {
        private string _name, _surname, _patronymic, _id;
        private MyCustomCollection<Passenger> Passengers = new MyCustomCollection<Passenger>();

        public Passenger(string name, string surname, string patronymic, string id)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _id = id;
        }
    }
}