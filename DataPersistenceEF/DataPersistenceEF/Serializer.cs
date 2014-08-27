//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataPersistence
//{
//    public static class Serializer
//    {
//        //http://blog.danskingdom.com/saving-and-loading-a-c-objects-data-to-an-xml-json-or-binary-file/
//        public static void SerializeObject<T>(string filePath, T objectToWrite, bool append = false)
//        {
//            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
//            {
//                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
//                binaryFormatter.Serialize(stream, objectToWrite);
//            }
//        }
//        public static T DeserializeObject<T>(string filePath)
//        {
//            using (Stream stream = File.Open(filePath, FileMode.Open))
//            {
//                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
//                return (T)binaryFormatter.Deserialize(stream);
//            }
//        }
//    }
//}
