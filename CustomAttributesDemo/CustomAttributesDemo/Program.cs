using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CustomAttributesDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public RangeAttribute()
        {

        }
    }

    public interface IWorker
    {
        string Name { get; set; }

        string City { get; set; }
    }

    public class Employee : IWorker
    {
        [Range(MaxLength = 5)]
        public string Name { get; set; }

        [Range(MaxLength = 6)]
        public string City { get; set; }
    }

    public class Manager : IWorker
    {
        [Range(MaxLength = 7)]
        public string Name { get; set; }

        [Range(MaxLength = 5)]
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Name: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Employee City: ");
            string empCity= Console.ReadLine();
            IWorker emp = new Employee { Name = empName, City = empCity };

            Console.WriteLine("Enter Manager Name: ");
            string mgrName = Console.ReadLine();
            Console.WriteLine("Enter Manager City: ");
            string mgrCity = Console.ReadLine();
            IWorker mgr = new Manager { Name = mgrName, City = mgrCity };

            List<IWorker> list = new List<IWorker> { emp, mgr };

            foreach (IWorker item in list)
            {
                Type type = item.GetType();

                PropertyInfo[] propertiesInfo = type.GetProperties();

                foreach (PropertyInfo propertyInfo in propertiesInfo)
                {
                    object[] attributes = propertyInfo.GetCustomAttributes(false);

                    foreach (var attribute in attributes)
                    {
                        if (attribute is RangeAttribute)
                        {
                            RangeAttribute rangeAttribute = attribute as RangeAttribute;

                            if (propertyInfo.Name.Equals("Name"))
                            {
                                if (item.Name.Length > rangeAttribute.MaxLength)
                                {
                                    Console.WriteLine("Type: " + type.Name + ", Property: " + propertyInfo.Name + " exceeds the defined length on attribute. Max Length allowed is : " + rangeAttribute.MaxLength);
                                }
                            }

                            else if (propertyInfo.Name.Equals("City"))
                            {
                                if (item.City.Length > rangeAttribute.MaxLength)
                                {
                                    Console.WriteLine("Type: " + type.Name + ", Property: " + propertyInfo.Name + " exceeds the defined length on attribute. Max Length allowed is : " + rangeAttribute.MaxLength);
                                }
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
