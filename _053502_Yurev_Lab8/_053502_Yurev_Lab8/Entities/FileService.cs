using System;
using System.Collections.Generic;
using System.IO;
using _053502_Yurev_Lab8.Interfaces;

namespace _053502_Yurev_Lab8.Entities
{
    public class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            string filePath = @"/Users/vadinamo/Documents/исп/_053502_Yurev_Lab8/_053502_Yurev_Lab8/" + fileName + ".dat";
            
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    int salary = reader.ReadInt32();
                    bool onVacation = reader.ReadBoolean();

                    yield return new Employee(name, salary, onVacation);
                }
                
                reader.Close();
            }
            
            Console.Clear();
            Console.WriteLine("\n###################################" +
                              "File was read successfully.\n" +
                              "###################################\n");
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            string filePath = $"/Users/vadinamo/Documents/исп/_053502_Yurev_Lab8/_053502_Yurev_Lab8/{fileName}.dat";
            
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                foreach(Employee e in data)
                {
                    writer.Write(e.GetName());
                    writer.Write(e.GetSalary());
                    writer.Write(e.GetOnVacation());
                }
                
                writer.Close();
            }
            
            Console.Clear();
            Console.WriteLine("###################################\n" +
                              "Data saved successfully.\n" +
                              "###################################\n");
        }
    }
}