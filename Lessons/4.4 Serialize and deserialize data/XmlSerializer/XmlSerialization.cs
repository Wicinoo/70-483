using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Lessons._4._4_Serialize_and_deserialize_data.XmlSerializer
{
    public class XmlSerialization
    {
        public void Run()
        {
            DefaultSingleSerialization();
            Console.WriteLine();
            //<? xml version = "1.0" encoding = "utf-16" ?>
            //<CrazyRootName xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema" >
            //    <FirstName>Jon</FirstName>
            //    <LastName>Lenon</LastName>
            //    <Age>10</Age>
            //</CrazyRootName>


            DefaultXmlSerializationForBinaryData();
            Console.WriteLine();
            //<? xml version="1.0" encoding="utf-16" ?>
            //<Test xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd="http://www.w3.org/2001/XMLSchema" >
            //    <Data>AQIFBgcFBg ==</Data>
            //</Test>


            SerializationWithNoDefaultEncoding();
            Console.WriteLine();

            DefaultSerializationForCollectionInRoot();
            Console.WriteLine();
            //<? xml version = "1.0" encoding = "utf-16" ?>
            //<ArrayOfPerson xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema" >
            //    <Person>
            //        <FirstName>Jon</FirstName>
            //        <LastName>Lenon</LastName>
            //        <Age>10</Age>
            //    </Person>
            //    <Person>
            //        <FirstName>Karel</FirstName>
            //        <LastName>Novak</LastName>
            //        <Age>11</Age>
            //    </Person>
            //</ArrayOfPerson>


            MissingPropertyDuringDeserialization();
            Console.WriteLine();
        }

        private static void MissingPropertyDuringDeserialization()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Person));
            var xml = string.Empty;
            using (var sw = new StringWriter())
            {
                var person = new Person()
                {
                    Age = 10,
                    FirstName = "John",
                    LastName = "Lennon",
                    PrivatePropertySet = "PrivatePropertyShouldntSerialized"
                };
                serializer.Serialize(sw, person);
                xml = sw.ToString();
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlNodeList node = document.DocumentElement.SelectNodes("/CrazyRootName");
            foreach (XmlNode item in node)
            {
                var old = item.ChildNodes.Item(0);
                item.RemoveChild(old);
            }

            //even if we remove item, deserializer will not throw error, but initialize property with default value
            xml = document.OuterXml;

            using (var sr = new StringReader(xml))
            {
                Person person = (Person)serializer.Deserialize(sr);
                Console.WriteLine("Missing xml element for property FirstName will not throw exception");
                Console.WriteLine(person.ToString());
            }
        }

        private static void DefaultXmlSerializationForBinaryData()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Test));
            var xml = string.Empty;
            using (var sw = new StringWriter())
            {
                byte[] data = new byte[] { 1, 2, 5, 6, 7, 5, 6 };
                var ob = new Test()
                {
                    Data = data
                };
                serializer.Serialize(sw, ob);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);
        }

        private static void SerializationWithNoDefaultEncoding()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Person));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            ns.Add("myNamespace", "http://test");
            ns.Add("prefix", "namespace");
            var xml = string.Empty;
            using (var sw = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;
                settings.OmitXmlDeclaration = true;
                //settings.Indent = true;
                //settings.IndentChars = "\t";
                //settings.NewLineChars = Environment.NewLine;
                //settings.ConformanceLevel = ConformanceLevel.Document;

                using (var xw = XmlWriter.Create(sw, settings))
                {
                    Person persons = new Person()
                    {

                        Age = 10,
                        FirstName = "Jon",
                        LastName = "Lenon"
                    };

                    serializer.Serialize(xw, persons, ns);
                    xml = Encoding.UTF8.GetString(sw.ToArray());
                }
            }
            Console.WriteLine(xml);
        }

        private static void DefaultSingleSerialization()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Person));
           
            var xml = string.Empty;
            using (var sw = new StringWriter())
            {
                Person persons = new Person()
                {

                    Age = 10,
                    FirstName = "Jon",
                    LastName = "Lenon"
                };

                serializer.Serialize(sw, persons);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);
        }

        private static void DefaultSerializationForCollectionInRoot()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            //as you can see in result, the root element name is different - it doesnt contains <ArrayOfCrazyRootName 
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Person>));
            var xml = string.Empty;
            using (var sw = new StringWriter())
            {
                List<Person> persons = new List<Person>()
                {
                    new Person()
                      {
                          Age = 10,
                          FirstName = "Jon",
                          LastName = "Lenon"
                      },
                    new Person()
                      {
                          Age = 11,
                          FirstName = "Karel",
                          LastName = "Novak"
                      }
                };
                serializer.Serialize(sw, persons);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);
        }
    }


    [Serializable]
    [XmlRoot("CrazyRootName")]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        string _privateProperty;

        public string PrivatePropertySet
        {
            set { _privateProperty = value; }
        }

        public override string ToString()
        {
            return string.Format("FirstName: {0}, LastName:{1}, Age:{2}, PrivateProperty:{3}", FirstName, LastName, Age, _privateProperty);
        }
    }

    [Serializable]
    public class Test
    {
        public byte[] Data { get; set; }
    }
}
