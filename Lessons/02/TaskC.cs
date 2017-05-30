using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        private static readonly BlockingCollection<Action> WritingAccessQueue = new BlockingCollection<Action>(); 

        private static readonly List<string> UsersTryingToWrite = new List<string>() { "Tomáš", "Jiří", "Marián", "Vadim", "Matěj", "Honza" };

        public static void Run()
        {
            //Not safe
            //Parallel.ForEach(UsersTryingToWrite, AccessFile);

            //Safe
            var listenerThread = new Thread(Listen) { Name = "Only this thread can write" };
            listenerThread.Start();
            Parallel.ForEach(UsersTryingToWrite, QueueFileAccess);

            Console.ReadKey();
            listenerThread.Abort();
        }

        private static void Listen()
        {
            while (true)
            {
                Action action;
                var success = WritingAccessQueue.TryTake(out action);

                if (success) action();
            }
        }

        private static void AccessFile(string username)
        {
            FileAccessor.GrantWriteAccess(username);
        }

        private static void QueueFileAccess(string username)
        {
            WritingAccessQueue.Add(() => FileAccessor.GrantWriteAccess(username));
        }

        private static class FileAccessor
        {
            private static bool _isOpen = true;

            public static void GrantWriteAccess(string username)
            {
                if(!_isOpen) throw new InvalidOperationException();

                _isOpen = false;

                DoChangesOnTheFile();

                Console.WriteLine($"File opened by {username} has been closed and is available for writing.");

                _isOpen = true;
            }

            private static void DoChangesOnTheFile()
            {
                //TODO: Do programs or whatever it is you developers do.

                Thread.Sleep(500);
            }
        }
    }
}