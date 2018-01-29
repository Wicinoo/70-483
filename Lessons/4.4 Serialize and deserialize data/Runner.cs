using Lessons._4._4_Serialize_and_deserialize_data.DataContract;
using Lessons._4._4_Serialize_and_deserialize_data.XmlSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4._4_Serialize_and_deserialize_data
{
    public static class Runner
    {
        public static void Run()
        {
            var defaultSerialization = new XmlSerialization();
           defaultSerialization.Run();

            BinarySerialization.BinarySerialization.Run();
            Console.ReadLine();

            DataContractSerialization.Run();
            Console.ReadLine();
        }
    }
}
