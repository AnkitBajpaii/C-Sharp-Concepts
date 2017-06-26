using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemo
{
    class Program
    {
        static void XmlSerialization()
        {
            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\TestData\\XmlSerializedEmployee.xml";
            Employee objectToBeSerialized = new Employee() { EmployeeName = "Ankit", EmployeeAge = 28 };
            Helper.XmlSerialize<Employee>(objectToBeSerialized, filePath);

            Employee newEmp = (Employee)Helper.XmlDeSerialize<Employee>(filePath);
            Console.WriteLine(newEmp.ToString());
        }

        static void BinarySerialization()
        {
            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\TestData\\BinarySerializedStudent.txt";
            Student objectToBeSerialized = new Student() { StudentName = "Ankit", StudentAge = 28 };

            Helper.BinarySerialize<Student>(objectToBeSerialized, filePath);

            Student newStudent = (Student)Helper.BinaryDeSerialize<Student>(filePath);
            Console.WriteLine(newStudent.ToString());
        }

        static void Main(string[] args)
        {
            XmlSerialization();

            BinarySerialization();

            Console.ReadKey();
        }
    }
}
