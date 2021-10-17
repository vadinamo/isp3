using System.Collections.Generic;
using _053502_Yurev_Lab8.Entities;

namespace _053502_Yurev_Lab8.Interfaces
{
    public interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}