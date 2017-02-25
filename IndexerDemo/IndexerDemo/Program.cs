using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexerDemo
{
    class Employee
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Employee() : this(String.Empty)
        {

        }

        public Employee(string _name)
        {
            name = _name;
        }

        public void ShowEmpDetails()
        {
            Console.WriteLine("Emp name: " + name);
        }

    }

    class Manager : Employee
    {
        public static int Limit = 3;

        Employee[] arrEmployees = new Employee[Limit];

        public string this[int index]
        {
            get
            {
                if (index > 0 && index < Limit)
                {
                    return arrEmployees[index].Name;
                }
                return "";

            }
            set
            {

                if (index >= 0 && index < Limit)
                {
                    arrEmployees[index] = new Employee(value);
                }
            }
        }

        public Employee this[string str]
        {
            get
            {
                if (!String.IsNullOrEmpty(str) && arrEmployees != null && arrEmployees.Length > 0)
                {
                    foreach (Employee emp in arrEmployees)
                    {
                        if (emp.Name.Equals(str))
                            return emp;
                    }

                }
                return null;

            }
        }

        public Manager(string name) : base(name)
        {

        }

        public Employee[] GetAllEmployees
        {
            get
            {
                return arrEmployees;
            }
        }

        public int GetEmployeeCountUnderManager()
        {
            if (arrEmployees != null)
            {
                return arrEmployees.Length;
            }
            return 0;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Ankit");
            manager[0] = "Akash";
            manager[1] = "Anuj";
            manager[2] = "Ravi";

            Console.WriteLine("Manager " + manager.Name + " has " + Manager.Limit + " employees under him: ");

            Employee[] arrEmployees = manager.GetAllEmployees;

            if (arrEmployees != null && arrEmployees.Length > 0)
            {
                foreach (Employee employee in arrEmployees)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.WriteLine("Search for employee , eneter name ");
            string name = Console.ReadLine();

            Employee emp = manager[name];
            if (emp != null)
                emp.ShowEmpDetails();
            else
                Console.WriteLine("No employee found with name : " + name);
            Console.ReadKey();

        }
    }
}
