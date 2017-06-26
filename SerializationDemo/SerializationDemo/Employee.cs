using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializationDemo
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }

        public override string ToString()
        {
            return string.Format("Employee Name: {0}, Employee Age: {1}", EmployeeName, EmployeeAge);
        }
    }
}
