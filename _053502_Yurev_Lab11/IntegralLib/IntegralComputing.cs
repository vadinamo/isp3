using System;
using System.Diagnostics;
using System.Threading;

namespace IntegralLib
{
    public class IntegralComputing
    {
        public double currentProgress;

        public delegate void getProgress(string progr);

        public event getProgress enterPress;
        
        public void Computing()
        {
            Console.WriteLine("Start thread: "+ Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            double integral = 0;
            double h = 0.000000001;
            
            for (double current = 0; current < 1; current += h)
            {
                integral += (Math.Sin(current) * h);
                currentProgress = current;
            }
            
            stopwatch.Stop();
            Console.WriteLine("Thread:"+ Thread.CurrentThread.ManagedThreadId +
                              "\nTime spent:" + stopwatch.Elapsed + 
                              "\nIntegral = " + integral);
        }

        public void DisplayMessage (string message)
        {
            Console.WriteLine(message);
        }

        public void GetCurrentProgress()
        {
            enterPress?.Invoke("Current progress: " + Math.Round(currentProgress * 100, 3) + "%");
        }
    }
}