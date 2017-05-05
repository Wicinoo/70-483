using System;
using System.Threading;

namespace Lessons._01
{
    public static class _06_DelegatesAdvancedTopics
    {
        delegate string FormatDateTime(DateTime dateTime);

        delegate void SimpleDelegate();

        public static void Run()
        {
            // Using lambda operator

            FormatDateTime czechFormat = dateTime => $"{dateTime:dd.MM.yyyy}";
            czechFormat += dateTime => $"{dateTime:dd.MM.yy}";

            Console.WriteLine($"Czech format: {czechFormat(DateTime.Now)}");

            // Asking for invocation list

            var invocations = czechFormat.GetInvocationList();

            foreach (var invocation in invocations)
            {
                Console.WriteLine($"invocation.Method: {invocation.Method}");
                Console.WriteLine($"invocation.Target: {invocation.Target}");
            }

            // Using asynchronous support

            SimpleDelegate simpleDelegate = () => { Thread.Sleep(1000); };

            Console.WriteLine("The delegate invoked asynchronously is starting ...");

            simpleDelegate.BeginInvoke(HandleEndOfSimpleDelegateInvocation, null);

            Console.WriteLine("Processing is going on ...");
        }

        private static void HandleEndOfSimpleDelegateInvocation(IAsyncResult asyncResult)
        {
            Console.WriteLine("The delegate invoked asynchronously has finished.");
        }
    }
}