using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {

        private static string[] sites = { "www.visualstudio.com", "www.microsoft.com", "www.google.com"};

        public static void Run()
        {
            //sequencial
            Console.WriteLine("*******************\n* Sequencial read *\n*******************");
            Stopwatch watch=new Stopwatch();
            watch.Start();
            foreach (string site in sites)
            {
                Console.WriteLine("Website " + site + " is loading.");
                ReadSite(site);
            }
            watch.Stop();
            Console.WriteLine("\nTime elapsed: {0}", watch.Elapsed);

            //Paralel
            Console.WriteLine("*****************\n* Paralel read *\n*****************");
            //Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            List<Task> tasks = new List<Task>();

            foreach (string site in sites)
            {
                tasks.Add(Task.Run(() =>
                {
                    Console.WriteLine("Website " + site + " is loading.");
                    ReadSite(site);
                }));
            }
            Task.WaitAll(tasks.ToArray());
            watch.Stop();
            Console.WriteLine("\nTime elapsed: {0}", watch.Elapsed);

        }

        private static string ReadSite(string site)
        {
            string data = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + site);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return data;
        }

    }
}