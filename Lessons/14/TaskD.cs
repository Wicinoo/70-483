//Task D: Read XML from http://www.currency-iso.org/dam/downloads/lists/list_one.xml and write all entities in format:
//ALGERIA, Algerian Dinar, DZD

using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace Lessons._14
{
    static class TaskD
    {
        public static void Run()
        {
			
			var document = new XmlDocument();

			document.LoadXml(new WebClient().DownloadString("http://www.currency-iso.org/dam/downloads/lists/list_one.xml"));

			var nodes = document.GetElementsByTagName("CcyNtry");

			foreach (XmlNode node in nodes)
			{
				var toPrint = new List<string>();
				foreach (XmlNode childNode in node.ChildNodes)
				{	
					switch (childNode.Name)
					{
						case "CtryNm":
						case "CcyNm":
						case "Ccy":
							toPrint.Add(childNode.InnerText);
							break;
					}
				}
				Console.WriteLine(String.Join(", ", toPrint));
			}
        }
    }
}
