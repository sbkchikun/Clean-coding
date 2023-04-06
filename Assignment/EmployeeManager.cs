using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Assignment
{
    public class EmployeeManager
    {
        private Dictionary<string, Employee> employees;

        public EmployeeManager()
        {
            this.employees = new Dictionary<string, Employee>();
        }

        public void AddEmployee(Employee e)
        {
            employees.Add(e.EmpName, e);
        }

        public Employee FindEmployee(string EmpName)
        {
            try
            {
                return employees[EmpName];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        public Dictionary<string, Employee>.ValueCollection GetAllEmployees()
        {
            return employees.Values;
        }
    }
}
