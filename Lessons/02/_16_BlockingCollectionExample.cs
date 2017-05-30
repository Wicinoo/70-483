using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _16_BlockingCollectionExample
    {
        private static readonly BlockingCollection<Action> _emailsQueue = new BlockingCollection<Action>();

        public static void Run()
        {
            // Set to false to demonstrate no thread-safety processing
            const bool ThreadSafetyProcessing = true;

            var recipients = new[] { "Recipient1", "Recipient2", "Recipient3" };

            if (ThreadSafetyProcessing)
            {

                var threadForListeningToRequests = new Thread(ProcessRequests);
                threadForListeningToRequests.Start();

                Parallel.ForEach(recipients, address => SendEmailSequentially(address));

                Console.ReadKey();

                threadForListeningToRequests.Abort();
            }
            else
            {
                Parallel.ForEach(recipients, address => SendEmailDirectly(address));
            }
        }

        private static void SendEmailDirectly(string address)
        {
            NotThreadSafetyEmailSender.SendEmail(address);
        }

        private static void SendEmailSequentially(string address)
        {
            var wasAddSuccessfull = _emailsQueue.TryAdd(
                () => NotThreadSafetyEmailSender.SendEmail(address));

            if (!wasAddSuccessfull) throw new InvalidOperationException("Problem with sending an email.");
        }

        private static void ProcessRequests()
        {
            Func<Action, bool> actionWithTrueResultWrapper = action =>
            {
                action();
                return true;
            };

            while (actionWithTrueResultWrapper(_emailsQueue.Take())) { }
        }
    }

    internal static class NotThreadSafetyEmailSender
    {
        private static bool _isSending;

        public static void SendEmail(string address)
        {
            if (_isSending) throw new InvalidOperationException();

            _isSending = true;

            Thread.Sleep(1000);

            Console.WriteLine("Email to {0} has been sent.", address);

            _isSending = false;
        }
    }
}