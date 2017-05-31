using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public static class TaskA
    {
        public static void Run()
        {
            Task<Pokus> t = Task.Run(() =>
                   {
                       Console.WriteLine("Current culture {0}", Thread.CurrentThread.CurrentCulture.ToString());
                       Console.WriteLine("Current UI culture {0}", Thread.CurrentThread.CurrentUICulture.ToString());
                       Console.WriteLine("IsAlive {0}", Thread.CurrentThread.IsAlive.ToString());
                       Console.WriteLine("IsBackground {0}", Thread.CurrentThread.IsBackground.ToString());
                       Console.WriteLine("Priority {0}", Thread.CurrentThread.Priority.ToString());
                       Console.WriteLine("ThreadState {0}", Thread.CurrentThread.ThreadState.ToString());
                       Console.WriteLine("ManagedThreadId {0}", Thread.CurrentThread.ManagedThreadId.ToString());

                       return new Pokus() { Jmeno = "aaaaa", Prijmeni = "bbbbb" };
                   });
            
            Console.WriteLine(t.Result.Jmeno + " " + t.Result.Prijmeni);
            
        }

    }

    public class Pokus
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
    }
}