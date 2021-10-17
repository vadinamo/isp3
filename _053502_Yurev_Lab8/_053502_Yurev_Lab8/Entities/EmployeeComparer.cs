using System;
using System.Collections.Generic;

namespace _053502_Yurev_Lab8.Entities
{
    public class EmployeeComparer:IComparer<Employee>
    {
        public int Compare(Employee e1, Employee e2)
        {
            if (e1.GetSalary() > e2.GetSalary())
                return 1;

            if (e1.GetSalary() < e2.GetSalary())
                return -1;
            
            else
                return 0;
        }
    }
}