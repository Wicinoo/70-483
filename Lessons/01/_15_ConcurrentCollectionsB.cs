using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01
{
    public static class _15_ConcurrentCollectionsB
    {
        public static void Run()
        {
            System.Collections.Concurrent.ConcurrentDictionary<string, int> wordCounts = new System.Collections.Concurrent.ConcurrentDictionary<string, int>();
            var keys = new string[] { "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one", "one" };
            Parallel.ForEach<string>(keys, (key =>
                {
                    wordCounts.AddOrUpdate(key, 1, (k, v) => v + 1);
                }));

            Console.WriteLine(wordCounts["one"]);
        }
    }
}

