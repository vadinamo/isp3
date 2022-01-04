using System;

namespace PassengerLib
{
    [Serializable]
    public class Passenger
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BaggageCount { get; set; }

        public Passenger(int id, string name, int baggageCount)
        {
            ID = id;
            Name = name;
            BaggageCount = baggageCount;
        }
    }
}