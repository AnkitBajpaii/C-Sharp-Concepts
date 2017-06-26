using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SerializationDemo
{
    [Serializable]
    public class Student : ISerializable
    {
        public string StudentName { get; set; }
        public int StudentAge { get; set; }

        public Student()
        {

        }
        public Student(SerializationInfo info, StreamingContext context)
        {
            StudentName = (string)info.GetValue("Name", typeof(String));
            StudentAge = (int)info.GetValue("Age", typeof(int));
        }

        public override string ToString()
        {
            return string.Format("Student Name: {0}, Student Age: {1}", StudentName, StudentAge);
        }

        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", StudentName);
            info.AddValue("Age", StudentAge);
        }
        #endregion
    }
}
