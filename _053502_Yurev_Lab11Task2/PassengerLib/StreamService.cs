using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace PassengerLib
{
    public class StreamService
    {
        static Mutex mutex = new Mutex();
        public Task WriteToStream(Stream stream) //записывает коллекцию из 100 объектов согласно заданию в поток stream
        {
            return Task.Run(() =>
            {                    
                mutex.WaitOne();
                Console.WriteLine("Start of write. \nThread: " + Thread.CurrentThread.ManagedThreadId);
                
                string[] names = { "Alexey", "Nikolay", "Ivan", "Petr", "Vasiliy" };
                List<Passenger> list = new List<Passenger>();
                
                for (int i = 0; i < 100; i++)
                {
                    var rand = new Random();
                    Passenger p = new Passenger((i + 1), names[rand.Next(names.Length)],rand.Next(0, 3));
                    list.Add(p);
                }
                
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
                
                Console.WriteLine("End of write. \nThread: " + 
                                  Thread.CurrentThread.ManagedThreadId +
                                  "\n########################################");
                mutex.ReleaseMutex();
            });
        }

        public Task CopyFromStream(Stream stream, string fileName) //копирует информацию из потока stream в файл с именем fileName
        {
            return Task.Run(() =>
            {
                mutex.WaitOne();
                Console.WriteLine("Copy from stream. \nThread: " + Thread.CurrentThread.ManagedThreadId);
                
                stream.Position = 0;
                string data = "";
                BinaryFormatter formatter = new BinaryFormatter();
                List<Passenger> deserializedList = (List<Passenger>)formatter.Deserialize(stream);
                
                foreach (Passenger p in deserializedList)
                {
                    data += p.ID + " ";
                    data += p.Name + " ";
                    data += p.BaggageCount + "\n";
                }
                
                File.WriteAllText(fileName, data);
                
                Console.WriteLine("End of copying. \nThread: " + 
                                  Thread.CurrentThread.ManagedThreadId +
                                  "\n########################################");
                mutex.ReleaseMutex();
            });
        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<Passenger, bool> filter) //считывает объекты (ИмяКласса – это имя класса согласно варианту)
                                                                                                 //из файла с именем filename и возвращает количество объектов,
                                                                                                 //удовлетвояющих условию filter.
        {
            List<Passenger> passengers = new List<Passenger>();
            string currentLine;

            Console.WriteLine("Getting statistics. \nThread: " + 
                              Thread.CurrentThread.ManagedThreadId + 
                              "\n########################################");
            
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while ((currentLine = await streamReader.ReadLineAsync()) != null)
                {
                    string[] lines = currentLine.Split(" ");
                    passengers.Add(new Passenger(Convert.ToInt32(lines[0]) - 1, lines[1], Convert.ToInt32(lines[2])));
                }
            }
            
            return passengers.Where(filter).Count();
        }
    }
}