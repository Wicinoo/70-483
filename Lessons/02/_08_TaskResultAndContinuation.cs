using System;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _08_TaskResultAndContinuation
    {
        public static void Run()
        {
            Task<int> task = Task.Run(() =>
            {
                return 42;
            });

            Console.WriteLine(task.Result); // Displays 42

            // Continuation task

            var continuationTask = task.ContinueWith(previousTask =>
            {
                return previousTask.Result * 2;
            });

            Console.WriteLine(continuationTask.Result); // Displays 84

            // Conditional continuations

            task.ContinueWith(previousTask =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            task.ContinueWith(previousTask =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task.ContinueWith(previousTask =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
    }
}