using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _053502_Yurev_Lab8.Entities;

namespace _053502_Yurev_Lab8
{
    class Program
    {
        public static string getPass(string fileName)
        {
            return (@"/Users/vadinamo/Documents/исп/_053502_Yurev_Lab8/_053502_Yurev_Lab8/" + fileName + ".dat");
        }
        
        static void Main(string[] args)
        {
            List<Employee> Employees = new List<Employee>();
            FileService fileService = new FileService();
            
            Employees.Add(new Employee("Nikita", 1000, true));
            Employees.Add(new Employee("Eugene", 950, false));
            Employees.Add(new Employee("Nikolai", 1750, true));
            Employees.Add(new Employee("Vladislav", 1450, false));
            Employees.Add(new Employee("Anatoliy", 2000, true));
            Employees.Add(new Employee("Michael", 900, false));

            Console.Clear();
            Console.WriteLine("Enter file name.");
            string fileName = Console.ReadLine();
            string filePath = getPass(fileName);

            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                fileService.SaveData(Employees, fileName);
                
                Console.WriteLine("Enter new file name.");
                fileName = Console.ReadLine();
                string newFilePath = getPass(fileName);
                
                if (File.Exists(newFilePath))
                    File.Delete(newFilePath);

                File.Move(filePath, newFilePath);
                IEnumerable<Employee> newEmployees = fileService.ReadFile(fileName);
                
                List<Employee> sortedEmployees = newEmployees.ToList();
                sortedEmployees.Sort(new EmployeeComparer());
                
                Console.Clear();
                Console.WriteLine("Original collection:");
                foreach (Employee e in Employees)
                {
                    Console.Write(e.GetName() + ", " + e.GetSalary() + "$, ");
                    if(e.GetOnVacation())
                        Console.WriteLine("on vacation");
                    else
                        Console.WriteLine("on work");
                }
                
                Console.WriteLine("\nSorted collection:");
                foreach (Employee e in sortedEmployees)
                {
                    Console.Write(e.GetName() + ", " + e.GetSalary() + "$, ");
                    if(e.GetOnVacation())
                        Console.WriteLine("on vacation");
                    else
                        Console.WriteLine("on work");
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}