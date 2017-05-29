using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            var watch = new Stopwatch();

            Console.WriteLine("Sequential Process");
            watch.Start();

            Task synchronousTasks = Task.Run(() => {
                var taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                taskFactory.StartNew(() => MakeRequest("www.microsoft.com"))
                .ContinueWith(previousTask => MakeRequest("www.google.com"))
                .ContinueWith(previousTask => MakeRequest("www.visualstudio.com"));
            });

            synchronousTasks.Wait();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch.Reset();

            Console.WriteLine("Parallel Process");
            watch.Start();

            Task parallelTask = Task.Run(() =>
            {
                var taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);

                taskFactory.StartNew(async () => await MakeRequest("www.microsoft.com"));
                taskFactory.StartNew(async () => await MakeRequest("www.google.com"));
                taskFactory.StartNew(async () => await MakeRequest("www.visualstudio.com"));
            });

            parallelTask.Wait();
            watch.Stop();

            Console.WriteLine(watch.Elapsed);
        }

        public static async Task<string> MakeRequest(string website)
        {
            using (var client = new HttpClient())
            {
                string result = await client.GetStringAsync(website);

                return result;
            }
        }
    }
}