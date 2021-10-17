using System;

namespace _053502_Yurev_Lab6.Entities
{
    public class MyException : Exception
    {
        private string _message;
        public MyException(string message)
        {
            _message = message;
            Console.WriteLine(_message);
        }

        public void ShowMessage()
        {
            Console.WriteLine(_message);
        }
    }
}