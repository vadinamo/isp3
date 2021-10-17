using System;
using _053502_Yurev_Lab6.Collections;

namespace _053502_Yurev_Lab6.Entities
{
    public class Journal
    {
        private MyCustomCollection<string> Events = new MyCustomCollection<string>();

        public void AddEvent(string _event)
        {
            Events.Add(_event);
        }

        public void ShowEvents()
        {
            Console.Clear();
            Console.WriteLine("###################################");

            if (Events.Count == 0)
            {
                Console.WriteLine("There is no events yet.");
                Console.WriteLine("###################################\n");
                return;
            }

            for (int i = 0; i < Events.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Events[i]);
            }
            
            Console.WriteLine("###################################\n");
        }
    }
}