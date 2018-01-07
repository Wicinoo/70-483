using System;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lessons._4._4_Serialize_and_deserialize_data.BinarySerialization
{
    public class BinarySerialization
    {
        public static void Run()
        {
            DefaultBinarySerializationAndDeserialization();
            Console.ReadLine();

            BinarySerializationInfluence();
            Console.ReadLine();

            SerializeObjectWitchImplementIserializable();
            Console.ReadLine();
        }

        private static void SerializeObjectWitchImplementIserializable()
        {
            var person = new PersonWithSerializeableInterface()
            {
                Id = 10,
                IsDirty = true,
                Name = "TestName",
                Password = "Password1"
            };

            byte[] data;
            IFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, person);
                data = stream.ToArray();
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

            using (var stream = new MemoryStream(data))
            {
                var result = (PersonWithSerializeableInterface)formatter.Deserialize(stream);
                Console.WriteLine(result.ToString());
            }
        }

        private static void BinarySerializationInfluence()
        {
            var personInfuence = new PersonInfluence()
            {
                Id = 10,
                Name = "test"
            };

            //we can create special context and on it we can change value
            var context = new StreamingContext(StreamingContextStates.Other, "test");
            IFormatter formatter = new BinaryFormatter(null, context);
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, personInfuence);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine(result);
            }
        }

        private static void DefaultBinarySerializationAndDeserialization()
        {
            IFormatter formatter = new BinaryFormatter();
            var xml = string.Empty;
            byte[] binData;
            using (var sw = new StringWriter())
            {


                using (var mw = new MemoryStream())
                {
                    var person = new Person()
                    {
                        FirstName = "John",
                        LastName = "Novak",
                        Age = 11,
                        PrivatePropertySet = "PrivatePropertyShouldBeSerialized"
                    };

                    formatter.Serialize(mw, person);
                    binData = mw.ToArray();
                    xml = Encoding.UTF8.GetString(binData);
                }

                using (var mr = new MemoryStream(binData))
                {
                    var result = (Person)formatter.Deserialize(mr);
                    Console.WriteLine(result.ToString());
                }
            }

        }
    }

    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [NonSerialized]  //this attribute can be set only on field, not on property
        string _nonSerialized;

        public string NonSerialized { get
            { return _nonSerialized; } set { _nonSerialized = value; } }
        string _privateMember;

        public string PrivatePropertySet
        {
            set
            {
                _privateMember = value;
            }
        }

        public override string ToString()
        {
            return string.Format("FirstName:{0}, LastName:{1}, Age:{2}, PrivateMember:{3}, NonSerialized:{4}", FirstName, LastName, Age, _privateMember, _nonSerialized);
        }
    }

    [Serializable]
    public class PersonInfluence
    {

        public int Id { get; set; }
        public string Name { get; set; }


        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine(string.Format("Context:{0}, State:{1}",context.Context, context.State));
            Console.WriteLine("OnSerializing");
        }

        [OnSerialized]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerialized");
        }

        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("OnDererializing");
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnDeserialized");
        }
    }

    [Serializable]
    public class PersonWithSerializeableInterface : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsDirty = false;

        public PersonWithSerializeableInterface()
        {      
        }
        //is called during deserialization
        protected PersonWithSerializeableInterface(SerializationInfo info, StreamingContext context)
        {
            Password = info.GetString("Value1");
        }

        //is called during serialization. Only values, which are saved to info, are serialized - others are ignored
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, 
            SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Value1", Password);  //we can here implement password coding
        }

        public override string ToString()
        {
            return string.Format("Id:{0}, Name:{1}, IsDirty:{2}, Password:{3}", Id, Name, IsDirty, Password);
        }
    }
}
