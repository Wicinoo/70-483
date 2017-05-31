using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public class TaskC
    {
        private List<int> _unsafeThreadCollection = new List<int>();
        private BlockingCollection<int> _safeCollection = new BlockingCollection<int>(); 
        public void Run()
        {
            var numberOfItems = 1000000; 
            var collection = Enumerable.Range(0, numberOfItems);
            Parallel.ForEach(collection, DoSomething);

            //longerg
            //Parallel.ForEach(collection,
            //i =>
            //{
            //    DoSomething(i);
            //});

            //really joke: sometimes there wasn't exception, but _unsafeThreadCollection.Count<numberOfItems
            //Console.WriteLine($"expected items:{numberOfItems}, real items:{_unsafeThreadCollection.Count}");

            Console.WriteLine($"expected items:{numberOfItems}, real items:{_safeCollection.Count}");
        }

        private void DoSomething(int i)
        {
            //_unsafeThreadCollection.Add(i);
            _safeCollection.Add(i);
        }
    }
}