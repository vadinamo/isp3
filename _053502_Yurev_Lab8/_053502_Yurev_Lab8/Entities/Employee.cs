namespace _053502_Yurev_Lab8.Entities
{
    public class Employee
    {
        private string Name;
        private int Salary;
        private bool OnVacation;

        public Employee()
        {
            Name = null;
            Salary = 0;
            OnVacation = false;
        }

        public Employee(string name, int salary, bool onVacation)
        {
            Name = name;
            Salary = salary;
            OnVacation = onVacation;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetSalary()
        {
            return Salary;
        }

        public bool GetOnVacation()
        {
            return OnVacation;
        }
    }
}