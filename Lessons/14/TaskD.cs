//Task D: Read XML from http://www.currency-iso.org/dam/downloads/lists/list_one.xml and write all entities in format:
//ALGERIA, Algerian Dinar, DZD

using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Lessons._14
{
    static class TaskD
    {
        public static void Run()
        {
            XDocument doc = XDocument.Load("http://www.currency-iso.org/dam/downloads/lists/list_one.xml");

            foreach (var node in doc.Root.Descendants("CcyTbl").Elements("CcyNtry"))
            {
                Console.WriteLine("{0}, {1}, {2}",node.Element("CtryNm").Value, node.Element("CcyNm").Value, node.Element("Ccy") != null ? node.Element("Ccy").Value : node.Element("CcyNm").Value);
            }
        }
    }
}
