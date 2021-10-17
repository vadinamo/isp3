namespace _053502_Yurev_Lab5.Entities
{
    public class Tariff
    {
        private string _from, _to;
        private int _price;
        
        public Tariff()
        {
            _from = "";
            _to = "";
            _price = 0;
        }
        
        public Tariff(string from, string to, int price)
        {
            _from = from;
            _to = to;
            _price = price;
        }

        public string GetDeparture()
        {
            return _from;
        }

        public string GetArrival()
        {
            return _to;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}