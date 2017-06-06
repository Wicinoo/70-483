using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _05_CancellationToken
    {
        public static void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, cancellationTokenSource.Token);

            Console.WriteLine("Press any key to stop the task");
            Console.ReadLine();

            cancellationTokenSource.Cancel();
        }
    }
}