using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _10_WaitingForTaskResults
    {
        public static void RunWaitAllExample()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            }
            );

            Task.WaitAll(tasks);
        }

        public static void RunWaitAnyExample()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int indexOfCompletedTask = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[indexOfCompletedTask];

                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(indexOfCompletedTask);
                tasks = temp.ToArray();
            }
        }
    }
}