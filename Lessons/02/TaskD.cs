using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);

            var sw = new Stopwatch();

            for (int i = 0; i < 15; i++)
            {
                sw.Restart();

                var t = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                sw.Stop();
                System.Console.WriteLine($"Elapsed ticks for thread {i}: {sw.ElapsedTicks}");
            }
        }
    }
}