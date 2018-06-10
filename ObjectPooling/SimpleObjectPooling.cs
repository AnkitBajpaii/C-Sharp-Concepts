using System;
using System.Collections;

namespace SimpleObjectPooling
{
    public class Employee
    {
        public static int Counter { get; set; }

        private static int IdCounter { get; set; }
        static Employee()
        {
            Counter = 0;
        }

        public Employee()
        {
            Counter++;

            IdCounter++;
            Id = IdCounter;
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return "Employee Id: " + Id;
        }
    }
        
    public class Factory
    {
        private static int _maxPoolSize;
        private static readonly Queue objPool = new Queue(_maxPoolSize);

        public Factory(int _maxPoolSize)
        {
            Factory._maxPoolSize = _maxPoolSize;
        }

        public Employee GetEmployee()
        {
            Employee emp;

            if(Employee.Counter >= _maxPoolSize && objPool.Count > 0)
            {
                emp = RetriveEmployeeFromPool();
            }
            else
            {
                emp = CreateNewEmployee();
            }

            return emp;
        }

        private Employee RetriveEmployeeFromPool()
        {
            if(objPool != null && objPool.Count > 0)
            {
                Employee emp = (Employee)objPool.Dequeue();
                Employee.Counter--;
                return emp;
            }

            return null;
        }

        private Employee CreateNewEmployee()
        {
            Employee emp = new Employee();
            objPool.Enqueue(emp);
            return emp;
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory(2);
            Employee emp1 = factory.GetEmployee();
            Console.WriteLine(emp1.ToString());

            Employee emp2 = factory.GetEmployee();
            Console.WriteLine(emp2.ToString());

            Employee emp3 = factory.GetEmployee();
            Console.WriteLine(emp3.ToString());

            Employee emp4 = factory.GetEmployee();
            Console.WriteLine(emp4.ToString());

            Employee emp5 = factory.GetEmployee();
            Console.WriteLine(emp5.ToString());

            Console.ReadKey();
        }
    }
}
