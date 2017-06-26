using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public static class Helper
    {
        #region XmlSerialization
        public static void XmlSerialize<T>(T objectToBeSerialized, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer writer = new XmlSerializer(typeof(T));
                writer.Serialize(fs, objectToBeSerialized);
            }
        }

        public static object XmlDeSerialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer reader = new XmlSerializer(typeof(T));
                return reader.Deserialize(fs);
            }
        }

        #endregion

        #region BinarySerialization
        public static void BinarySerialize<T>(T objectToBeSerialized, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, objectToBeSerialized);
            }
        }

        public static object BinaryDeSerialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(fs);
            }
        }
        #endregion
    }
}
