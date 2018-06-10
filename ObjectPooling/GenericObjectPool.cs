using System;
using System.Collections;
using System.Collections.Concurrent;

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
       
    public class ObjectPool<T> where T: new()
    {
        private readonly ConcurrentBag<T> objPool = new ConcurrentBag<T>();
        private int maxPoolSize;
        private int counter;
        public ObjectPool(int maxPoolSize)
        {
            this.maxPoolSize = maxPoolSize;
        }

        public T GetObject()
        {
            T item;

            if(counter >= maxPoolSize && objPool.TryTake(out item))
            {
                Console.WriteLine("Getting from pool");
                counter--;
                return item;
            }
            else
            {
                Console.WriteLine("creating new and adding to pool");
                T obj = new T();
                objPool.Add(obj);
                counter++;
                return obj;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int poolSize = 2;
            Console.WriteLine("Max pool size: {0}", poolSize);

            ObjectPool<Employee> objPool = new ObjectPool<Employee>(poolSize);
            Employee emp1 = objPool.GetObject();
            Console.WriteLine(emp1.ToString());

            Employee emp2 = objPool.GetObject();
            Console.WriteLine(emp2.ToString());

            Employee emp3 = objPool.GetObject();
            Console.WriteLine(emp3.ToString());

            Employee emp4 = objPool.GetObject();
            Console.WriteLine(emp4.ToString());

            Employee emp5 = objPool.GetObject();
            Console.WriteLine(emp5.ToString());

            Employee emp6 = objPool.GetObject();
            Console.WriteLine(emp6.ToString());

            Console.ReadKey();
        }
    }
}
