using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers
{
    public class WebRequestToFile
    {
        public static void Run()
        {
            WebRequest request = WebRequest.Create("http://www.seznam.cz");
            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    using (var writter = new StreamWriter("response.txt"))
                    {
                        writter.Write(reader.ReadToEnd());
                    }
                }

            }
        }
    }
}
