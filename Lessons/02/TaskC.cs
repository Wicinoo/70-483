using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public static class TaskC
    {
        public static void Run()
        {

            //unsafe
            string[] cities = {"Praha","Brno","Ostrava","Plzen","Kosice","Bratislava" };

            Parallel.ForEach(cities, city =>
            {
                Console.WriteLine("ForEach: {0} {1}",city, StrCount(city));
            });


            //concurent
            ConcurrentBag<string> cCities= new ConcurrentBag<string>();
            cCities.Add("Praha");
            cCities.Add("Brno");
            cCities.Add("Ostrava");
            cCities.Add("Plzen");
            cCities.Add("Kosice");
            cCities.Add("Bratislava");

            Task.Run(() =>
            {
                foreach (string city in cCities)
                    Console.WriteLine("ForEach: {0} {1}", city, StrCount(city));
            }).Wait();

        }

        private static int StrCount(string strItem)
        {
            Thread.Sleep(200);
            return strItem.Length;
        }
    }
}