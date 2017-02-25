using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace ReflectionDemo1
{
    class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Person()
        {

        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void DisplayPersonDetails()
        {
            Console.WriteLine("Name:{0}, Age:{1}", this.Name, this.Age);
        }
    }

    class MyUtilClass
    {
        public static void ChangePropertyAtRunTime(PropertyInfo prop, string val, object Instance)
        {
            if (prop != null)
            {
                Console.WriteLine("Enter new value for {0} :", val);
                string newValue = Console.ReadLine();
                int res;
                if (prop.PropertyType.Equals(typeof(Int32)))
                {
                    bool isIntVal = Int32.TryParse(newValue, out res);
                    if (isIntVal)
                    {
                        prop.SetValue(Instance, res, null);
                        Console.WriteLine("New value for {0} is {1}", val, prop.GetValue(Instance, null));
                    }
                    else
                        Console.WriteLine("Type mismatch");
                }
                else if (prop.PropertyType.Equals(typeof(string)))
                {
                    prop.SetValue(Instance, newValue, null);
                    Console.WriteLine("New value for {0} is {1}", val, prop.GetValue(Instance, null));
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Property {0} not found.", val);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            Type pTyp;

            pTyp = types.Where(t => t.Name.Equals("Person")).FirstOrDefault();

            if (pTyp != null)
            {
                ConstructorInfo ctr = pTyp.GetConstructor(new Type[] { typeof(string), typeof(int) });
                do
                {
                    if (ctr != null)
                    {
                        object instance = ctr.Invoke(new object[] { "Ankit", 27 });
                        if (instance != null)
                        {
                            MethodInfo method = pTyp.GetMethod("DisplayPersonDetails");
                            if (method != null)
                            {
                                method.Invoke(instance, null);

                                Console.WriteLine("Do you want to change the value of properties at run time (Y/N)?");
                                string proceed = Console.ReadLine();
                                if (proceed.Equals("Y") || proceed.Equals("y"))
                                {
                                    Console.WriteLine("Available properties whose value can be changed are:");
                                    PropertyInfo[] propInfos = pTyp.GetProperties();

                                    for (int i = 0; i < propInfos.Length; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + propInfos[i].Name);
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("Enter the propety name or it's index");
                                    string val = Console.ReadLine();
                                    int res;
                                    bool isIndex = Int32.TryParse(val, out res);

                                    if (isIndex)
                                    {
                                        int actualIndex = res - 1;

                                        try
                                        {
                                            PropertyInfo prop = propInfos[actualIndex];
                                            MyUtilClass.ChangePropertyAtRunTime(prop, prop.Name, instance);

                                        }
                                        catch (IndexOutOfRangeException e)
                                        {
                                            Console.WriteLine("Invalid index entered: " + e.ToString());
                                        }
                                    }
                                    else
                                    {
                                        PropertyInfo prop = propInfos.Where(x => x.Name.Equals(val)).FirstOrDefault();
                                        MyUtilClass.ChangePropertyAtRunTime(prop, val, instance);
                                    }

                                }

                                Console.WriteLine("Thanks for interest in reflection !!!");

                            }
                        }
                    }
                    Console.WriteLine(Environment.NewLine + "Do you want to continue playing with Reflection in C#: ");

                } while (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase));

            }

        }
    }
}
