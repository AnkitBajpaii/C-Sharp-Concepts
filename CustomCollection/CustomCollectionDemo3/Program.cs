using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CustomCollectionDemo3
{
    class Employee
    {
        int empID;
        string empName;

        public int EmpID
        {
            get
            {
                return empID;
            }

            set
            {
                empID = value;
            }
        }

        public string EmpName
        {
            get
            {
                return empName;
            }

            set
            {
                empName = value;
            }
        }

        public Employee()
            : this(0, null)
        {

        }
        public Employee(int _empID)
            : this(_empID, null)
        {

        }
        public Employee(int _empID, string _empName)
        {
            empID = _empID;
            empName = _empName;
        }
    }

    class CustomCollection<T> : CollectionBase, IEnumerable<T>
    {
        public CustomCollection()
        {

        }

        public T this[int index]
        {
            get { return (T)this.List[index]; }
            set { this.List[index] = value; }
        }

        public void Add(T item)
        {
            this.List.Add(item);
        }

        public void Remove(T item)
        {
            this.List.Remove(item);
        }


        public void AddRange(CustomCollection<T> collection)
        {

            for (int i = 0; collection != null && i < collection.Count; i++)
            {
                this.List.Add(collection[i]);
            }

        }

        public bool Contains(T item)
        {
            return this.List.Contains(item);
        }

        public void Insert(int index, T item)
        {
            this.List.Insert(index, item);
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new CustomCollectionEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class CustomCollectionEnumerator<T> : IEnumerator<T>
    {
        public CustomCollectionEnumerator()
            : this(null)
        {

        }

        public CustomCollectionEnumerator(CustomCollection<T> _list)
        {
            list = _list;
        }

        CustomCollection<T> list = new CustomCollection<T>();
        private int _position = -1;

        public T Current
        {
            get
            {
                return list[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return list[_position];
            }
        }

        public void Dispose()
        {
            //
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < list.Count);
        }

        public void Reset()
        {
            _position = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<Employee> empList = new CustomCollection<Employee>();

            Employee emp1 = new Employee();
            emp1.EmpID = 1;
            emp1.EmpName = "ankit";
            empList.Add(emp1);

            Employee emp2 = new Employee();
            emp2.EmpID = 2;
            emp2.EmpName = "anu";
            empList.Add(emp2);

            IEnumerator<Employee> enume = empList.GetEnumerator();

            while (enume.MoveNext())
            {
                Employee item = enume.Current;
                Console.WriteLine(item.EmpID + " , " + item.EmpName);
            }


            foreach (Employee item in empList)
            {
                Console.WriteLine(item.EmpID + " , " + item.EmpName);
            }


            Console.ReadKey();
        }
    }
}
