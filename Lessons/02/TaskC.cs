using System;
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
            var numbers =  new int[] { 1, 2, 3 };

            Parallel.ForEach(numbers, number =>
            {
                number++;
            });

            Console.ReadKey();
        }
    }
}