using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _06_ThrowingOperationCanceledException
    {
        public static void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token);

            try
            {
                Console.WriteLine("Press any key to stop the task");
                Console.ReadLine();
                cancellationTokenSource.Cancel();

                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
        }
    }
}