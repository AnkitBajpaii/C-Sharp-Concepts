using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LinqDemo1
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public static List<Department> PopulateDepartmentData()
        {
            return new List<Department>
            {
              new Department{ DepartmentId = 1, Name = "Account" },
              new Department{ DepartmentId = 2, Name = "Sales" },
              new Department{ DepartmentId = 3, Name = "Marketing"}
            };
        }

    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }

        public static List<Employee> PopulateEmployeeData()
        {
            return new List<Employee>
            {
              new Employee{ EmployeeId = 1, EmployeeName = "A", DepartmentId=1 },
              new Employee{ EmployeeId = 2, EmployeeName = "B", DepartmentId=2 },
              new Employee{ EmployeeId = 3, EmployeeName = "C", DepartmentId=1 }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Linq Filtering Operators
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };

            IEnumerable<string> shortWords = words.Where(str => str.Length < 5);
            var shrtWrds = from word in words where word.Length < 5 select word;
            #endregion

            #region Linq Join
            List<Employee> employees = Employee.PopulateEmployeeData();
            List<Department> departments = Department.PopulateDepartmentData();
            var list = from e in employees
                       join d in departments on e.DepartmentId equals d.DepartmentId
                       select new
                       {
                           EmployeeId = e.EmployeeId,
                           EmployeeName = e.EmployeeName,
                           DepartmentName = d.Name
                       };
            Console.WriteLine("Employee ID \t Employee Name \t Department Name");
            foreach (var v in list)
            {
                Console.WriteLine("{0} \t\t {1} \t\t\t {2}", v.EmployeeId, v.EmployeeName, v.DepartmentName);
            }

            #endregion

            #region Linq Projection Operator

            #region Select

            List<string> wrds = new List<string>() { "an", "apple", "a", "day" };

            var query = from word in wrds
                        select word.Substring(0, 1);

            foreach (string s in query)
                Console.WriteLine(s);

            #endregion 

            #region Select Many

            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };
            query = from phrase in phrases
                    from word in phrase.Split(' ')
                    select word;
            foreach (string s in query)
                Console.WriteLine(s);
            #endregion

            #endregion

            #region Linq Sorting Operators
            query = from word in wrds orderby word select word;
            foreach (string s in query)
                Console.WriteLine(s);
            #endregion

            Console.ReadKey();


        }
    }
}
