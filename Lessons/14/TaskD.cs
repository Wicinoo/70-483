//Task D: Read XML from http://www.currency-iso.org/dam/downloads/lists/list_one.xml and write all entities in format:
//ALGERIA, Algerian Dinar, DZD

using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.XPath;

//Task D: Read XML from http://www.currency-iso.org/dam/downloads/lists/list_one.xml and write all entities in format:
//ALGERIA, Algerian Dinar, DZD

namespace Lessons._14
{
    static class TaskD
    {
        public static void Run()
        {
            string address = "http://www.currency-iso.org/dam/downloads/lists/list_one.xml";
            XmlDocument doc = GetXMLFromURL(address);

            ProcessXML(doc); //read and print the stuff in format above
        }

        private static void ProcessXML(XmlDocument doc)
        {
            XPathNavigator nav = doc.CreateNavigator();
            string query = "//CcyTbl/CcyNtry";
            XPathNodeIterator iterator = nav.Select(query);

            while (iterator.MoveNext())
            {
                string CtryNm = iterator.Current.SelectSingleNode("CtryNm").Value;
                string CcyNm = iterator.Current.SelectSingleNode("CcyNm").Value;
                string Ccy = string.Empty;
                if (iterator.Current.SelectSingleNode("Ccy") != null)
                {
                    Ccy = iterator.Current.SelectSingleNode("Ccy").Value; }

                string CcyNbr = string.Empty;
                if (iterator.Current.SelectSingleNode("CcyNbr") != null)
                {
                    CcyNbr = iterator.Current.SelectSingleNode("CcyNbr").Value;
                }

                string CcyMnrUnts = string.Empty;
                if (iterator.Current.SelectSingleNode("CcyMnrUnts") != null)
                {
                    CcyMnrUnts = iterator.Current.SelectSingleNode("CcyMnrUnts").Value;
                }
                
                Console.WriteLine($"{CtryNm}, {CcyNm}, {Ccy}");
            }
        }

        private static XmlDocument GetXMLFromURL(string address)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(address);
            return xmlDocument;
        }


    }
}
