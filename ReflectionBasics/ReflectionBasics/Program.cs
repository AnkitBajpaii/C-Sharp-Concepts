using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

namespace RelectionDemo
{
    class Employee
    {
        /* Automatic Properties */
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }

        /* Constructor chaining*/

        public Employee() : this(null)
        {

        }

        public Employee(string name) : this(name, 0)
        {

        }

        public Employee(string name, int age) : this(name, age, null)
        {
        }

        public Employee(string name, int age, string emailId)
        {
            this.Name = name;
            this.Age = age;
            this.EmailId = emailId;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("Employee Name: " + this.Name + "\nEmployee Age: " + this.Age + "\nEmployee Email Id: " + this.EmailId);
        }

        public void SetProperty(PropertyInfo propertyInfo, object value)
        {
            switch (propertyInfo.PropertyType.Name)
            {
                case "Int32":
                    propertyInfo.SetValue(this, Convert.ToInt32(value), null);
                    break;
                case "String":
                    propertyInfo.SetValue(this, value.ToString(), null);
                    break;
            }
        }
    }
    class Program
    {
        static void UsingReflection()
        {
            //Get Current executing assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //loading assembly dynamically, provide absolute path
            //Assembly currentAssembly = Assembly.LoadFile(@"C:\Users\ANKIT\Study\Self made Projects\ReflectionBasics\ReflectionBasics\bin\Debug\ConsoleApplication5.exe");

            //getting type from an assembly
            string typeName = Console.ReadLine().Trim();
            Type type = assembly.GetTypes().Where(_type => _type.Name.Equals(typeName)).FirstOrDefault();

            if (type != null)
            {
                Console.WriteLine("...........The type is: " + type.Name + "...........");

                ConstructorInfo ctor = type.GetConstructor(new Type[] { });
                //For finding parametrized constructor
                //ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(Int32), typeof(string) });

                if (ctor != null)
                {
                    Console.WriteLine("...........Found constructor of " + type.Name + " class...........");

                    Console.WriteLine("...........Invoking constructor and creating instance of " + type.Name + " class...........");

                    //creating instance
                    //object[] param = new object[] { "Ankit", 27,"ankitbajpaib070@gmail.com" };
                    // object instance = ctor.Invoke(param);

                    object instance = ctor.Invoke(null);

                    //can be done as below
                    //object instance = Activator.CreateInstance(type);

                    if (instance != null)
                    {
                        //get all propeties in current type
                        PropertyInfo[] propInfos = type.GetProperties();

                        //get particu;ar method in current type
                        MethodInfo mehtodInfo = type.GetMethod("SetProperty");

                        //setting property at run time
                        foreach (PropertyInfo item in propInfos)
                        {
                            Console.WriteLine("Please enter " + item.Name);
                            mehtodInfo.Invoke(instance, new object[] { item, Console.ReadLine() });
                        }

                        Console.WriteLine("Getting method of " + type.Name + " class..........");

                        MethodInfo methodInfo = type.GetMethod("DisplayEmployeeDetails");

                        if (methodInfo != null)
                        {
                            Console.WriteLine("...........Found method " + methodInfo.Name + " in " + type.Name + " class...........");
                            Console.WriteLine("...........Invoking method " + methodInfo.Name + "..........");
                            Console.WriteLine(methodInfo.Invoke(instance, null));
                        }
                        else
                            Console.WriteLine("...........Unable to find method specified in " + type.Name + " class...........");
                    }
                    else
                        Console.WriteLine("...........Unable to create instance of " + type.Name + " class...........");

                }
                else
                    Console.WriteLine("...........Unable to get desired constructor in " + type.Name + " class...........");
            }
            else
                Console.WriteLine("...........Unable to get type : " + typeName);            
        }


        static void Main(string[] args)
        {
            do
            {
                UsingReflection();

                Console.WriteLine("Do you want to continue(y/n)?");

            } while(!Console.ReadLine().Equals("n"));
        }
    }
}
