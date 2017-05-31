using System;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        public static void Run()
        {
            try
            {
                //The System.Collections.Concurrent namespace provides several thread-safe collection classes that should 
                //be used in place of the corresponding types in the System.Collections and System.Collections.Generic 
                //namespaces whenever multiple threads are accessing the collection concurrently.

                //ConcurrentQueue<T> is a thread-safe collection, 
                //while Queue is thread-unsafe collection (it's in System.Collections).

                //ConcurrentDictionary<TKey, TValue> is a thread-safe collection, 
                //while Dictionary<TKey, TValue> is a thread-unsafe collection (it's in System.Collections.Generic).

                // Create a new dictionary of strings, with string keys.
                Dictionary<int, string> ThreadUnsafeDictionary = new Dictionary<int, string>();

                // Add some elements to the dictionary.
                for (int i = 0; i < 100; i = i + 1)
                {
                    ThreadUnsafeDictionary.Add(i, i.ToString());
                }

                Dictionary<int, string> ThreadUnsafeDictionary2 = new Dictionary<int, string>();

                // run Parallel.ForEach() 
                /* Parallel.ForEach(ThreadUnsafeDictionary, currentElement =>
                //foreach (KeyValuePair<int string> currentElement in ThreadUnsafeDictionary)
                {
                    int j = currentElement.Key;

                    if (IsEven(j))

                    {
                        ThreadUnsafeDictionary2.Add(currentElement.Key, currentElement.Value);
                        ThreadUnsafeDictionary2.Remove(currentElement.Key);
                        Console.WriteLine("Processing {0} on thread {1}", currentElement, Thread.CurrentThread.ManagedThreadId);
                    }
                }); */

                ConcurrentDictionary<int, string> ThreadSafeDictionary = new ConcurrentDictionary<int, string>();

                for (int i = 0; i < 100; i = i + 1)
                {
                    ThreadSafeDictionary.GetOrAdd(i, i.ToString());
                }

                Parallel.ForEach(ThreadSafeDictionary, currentElement =>
                //foreach (KeyValuePair<int string> currentElement in ThreadUnsafeDictionary)
                {
                    int j = currentElement.Key;

                    if (IsEven(j))

                    {
                        Console.WriteLine("Processing {0} on thread {1}", currentElement, Thread.CurrentThread.ManagedThreadId);
                    }
                });

                // run Parallel.ForEach() 
                /* Parallel.ForEach(ThreadSafeDictionary, currentElement =>
                    {
                        Console.WriteLine("Processing {0} on thread {1}", currentElement, Thread.CurrentThread.ManagedThreadId);
                        //Console.WriteLine(currentElement.Key + " " + currentElement.Value);
                    }); */
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("There where {0} exceptions", ae.InnerExceptions.Count);
                // This is where you can choose which exceptions to handle.
                foreach (var ex in ae.InnerExceptions)
                {
                    if (ex is ArgumentException)
                        Console.WriteLine(ex);
                    else
                        throw ex;
                }
            }
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }
}