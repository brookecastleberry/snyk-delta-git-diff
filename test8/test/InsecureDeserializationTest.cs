using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace test_project8
{
    public class InsecureDeserializationTest
    {
        public object DeserializeData(byte[] data)
        {
            // Insecure deserialization vulnerability
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(data))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}
