using System;
using System.Diagnostics;
using System.Threading;

namespace Lessons._02
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using Rhino.Mocks.Constraints;
    using Rhino.Mocks.Impl;

    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            List<string> sites = new List<string>(new string[] { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" });

            var st = new Stopwatch();


            // Serial

            st.Start();
            sites.ForEach(
                site =>
                    {
                        Console.WriteLine();
                        var task = GetWebsite(site);
                        task.Wait();
                        //Console.WriteLine(task.Result);
                        Console.WriteLine(site);
                    });
            st.Stop();

            Console.WriteLine(st.Elapsed);


            //// Parallel

            //st.Reset();
            //st.Start();

            //Task[] tasks = new Task[3];

            //tasks[0] = Task.Run(() => {
            //        var task = GetWebsite(sites[0]);
            //        task.Wait();
            //        return task.Result;
            //});

            //tasks[1] = Task.Run(() => {
            //    var task = GetWebsite(sites[1]);
            //    task.Wait();
            //    return task.Result;
            //});

            //tasks[2] = Task.Run(() => {
            //    var task = GetWebsite(sites[2]);
            //    task.Wait();
            //    return task.Result;
            //});

            //Task.WaitAll(tasks);

            //st.Stop();
            //Console.WriteLine(st.Elapsed);


            st.Reset();
            st.Start();

            Task<string>[] tasks = new Task<string>[3];

            tasks[0] = GetWebsite(sites[0]);
            tasks[1] = GetWebsite(sites[1]);
            tasks[2] = GetWebsite(sites[2]);

            Task.WaitAll(tasks);

            st.Stop();
            Console.WriteLine(st.Elapsed);
        }

        public static async Task<string> GetWebsite(string address)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(address);
                return result;
            }
        }
    }
}