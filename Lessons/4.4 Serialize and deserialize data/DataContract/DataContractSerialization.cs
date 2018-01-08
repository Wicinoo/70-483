using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Lessons._4._4_Serialize_and_deserialize_data.DataContract
{
    public class DataContractSerialization
    {

        public static void Run()
        {
            DataContractSerializer();
            Console.ReadLine();

            DataContractJsonSerializer();
            Console.ReadLine();

        }

        private static void DataContractJsonSerializer()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var person = new PersonDataContract()
            {
                Id = 1111,
                Name = "This is test name",
                IsDirty = true
            };

            byte[] data;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(PersonDataContract));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, person);
                data = stream.ToArray();
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }

            using (var stream = new MemoryStream(data))
            {
                var result = (PersonDataContract)serializer.ReadObject(stream);
                Console.WriteLine(result.ToString());

            }
        }

        private static void DataContractSerializer()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            PersonDataContract input = new PersonDataContract()
            {
                Id = 10,
                Name = "TestName",
                IsDirty = true
            };

            byte[] data;
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(PersonDataContract));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, input);
                data = stream.ToArray();
                //Console.WriteLine(Encoding.UTF8.GetString(data));
                stream.Position = 0;
                using (var mr = new StreamReader(stream))
                {
                    Console.WriteLine(mr.ReadToEnd());
                }
            }

            using (var stream = new MemoryStream(data))
            {
                var output = (PersonDataContract)serializer.ReadObject(stream);
                Console.WriteLine(output.ToString());
            }
        }

        [DataContract]
        public class PersonDataContract
        {
            public PersonDataContract()   //constructor is not called during deserialization 
            {
                Console.WriteLine("ConstructorWasCalled");
                _privateMember = "TestValue";
            }

            [DataMember]                 //private member is serialized as well - if is marked by attribute
            string _privateMember; 

            [DataMember]
            public int Id { get; set; }

            [DataMember]
            public string Name { get; set; }

            public bool IsDirty = false;

            public override string ToString()
            {
                return string.Format("Id:{0}, Name:{1}, IsDirty:{2}, PrivateMember:{3}", Id, Name, IsDirty, _privateMember);
            }
       

        }
    }

}
