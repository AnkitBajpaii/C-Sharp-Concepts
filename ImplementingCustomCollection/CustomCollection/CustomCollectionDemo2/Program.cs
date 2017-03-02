using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CustomCollectionDemo2
{
    public class EmployeeEnumerator : IEnumerable
    {
        EmployeeCollection collection = new EmployeeCollection();

        public EmployeeEnumerator(EmployeeCollection _collection)
        {
            collection = _collection;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Employee
    {
        public Employee()
        {

        }

        private int _Age;
        private string _Name;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public class EmployeeCollection : CollectionBase
    {
        public EmployeeCollection()
        {

        }

        public Employee this[int index]
        {
            get
            {
                return (Employee)this.List[index];

            }

            set
            {
                this.List[index] = value;
            }
        }

        public void Add(Employee item)
        {
            this.List.Add(item);
        }

        public void Remove(Employee item)
        {
            this.List.Remove(item);
        }

        public int IndexOf(Employee item)
        {
            return base.List.IndexOf(item);
        }

        public bool Contains(Employee item)
        {
            return this.List.Contains(item);
        }

        public void Insert(int index, Employee item)
        {
            this.List.Insert(index, item);
        }

        public void AddRange(EmployeeCollection collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                this.List.Add(collection[i]);
            }
        }

        public void AddRange(Employee[] collection)
        {
            this.AddRange(collection);
        }

        public void CopyTo(Array array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public EmployeeEnumerator GetEmployeeEnumerator()
        {
            return new EmployeeEnumerator(this);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee { Name="Ankit",Age=20};
            Employee emp2 = new Employee { Name = "Anu", Age = 20 };
            Employee emp3 = new Employee { Name = "Ankit", Age = 20 };
            Employee emp4 = new Employee { Name = "Ankit", Age = 20 };

            EmployeeCollection collection = new EmployeeCollection();
            collection.Add(emp1);
            collection.Add(emp2);
            collection.Add(emp3);
            collection.Add(emp4);

            collection.Remove(emp4);
            Console.WriteLine("Without using custom enumerator");
            foreach (Employee item in collection)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Using custom enumerator");
            foreach (Employee item in collection.GetEmployeeEnumerator())
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();


        }
    }
}
