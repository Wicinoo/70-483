using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _09_ChildTasks
    {
        public static void Run()
        {
            Task<int[]> task = Task.Run(() =>
            {
                var results = new int[6];

                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                // Simplifying by using TaskFactory, no repeating usage of TaskCreationOptions

                TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                taskFactory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    results[3] = 3;
                });
                taskFactory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    results[4] = 4;
                });
                taskFactory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    results[5] = 5;
                });

                return results;
            });

            var finalTask = task
                .ContinueWith(parentTask => 
                {
                    foreach (int particularTaskResult in parentTask.Result)
                    {
                        Console.WriteLine(particularTaskResult);
                    }
                });

            finalTask.Wait();
        }
    }
}