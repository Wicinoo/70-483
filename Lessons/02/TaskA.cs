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
                       return new Pokus() { Jmeno = "aaaaa", Prijmeni = "bbbbb" };
                   }).ContinueWith((j) =>
                   {
                       ExecutionContext eC = ExecutionContext.Capture();
                      // var od=eC.GetObjectData(t,);
                       return new Pokus() { Jmeno = j.Result.Prijmeni, Prijmeni = j.Result.Jmeno };
                   }, TaskContinuationOptions.OnlyOnRanToCompletion);
            
            Console.WriteLine(t.Result.Jmeno + " " + t.Result.Prijmeni);
            
        }

    }

    public class Pokus
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
    }
}