using System;
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
    public struct TaskC
    {
        public static void Run()
        {
            var nameAges = new NameAge[]
            {
                new NameAge {Name = "Alex", Age = 10},
                new NameAge {Name = "Filip", Age = 20},
                new NameAge {Name = "Alex", Age = 30},
                new NameAge {Name = "Alex", Age = 30},
                new NameAge {Name = "Alex", Age = 30},
                new NameAge {Name = "Alex", Age = 30}
            };

            var dict = new Dictionary<string, int>();

            Parallel.ForEach(nameAges, new ParallelOptions
            {
                MaxDegreeOfParallelism = 6
            }, item =>
            {
                if (!dict.ContainsKey(item.Name))
                {
                    dict.Add(item.Name, item.Age);
                }
            });
        }

        class NameAge
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}