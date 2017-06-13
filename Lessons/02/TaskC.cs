using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography;
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
            //Unsafe();

            Safe();
        }

        private static void Unsafe()
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < 100; i++)
            {
                dict.Add(i, i);
            }

            Parallel.ForEach(dict, pair =>
            {  
                var i = pair.Key;
                var iminus = Math.Max(i - 1, 0);
                var iplus = Math.Min(i + 1, 100);

                dict[iminus] = dict[i];
                dict[iplus] = dict[i];

                Console.WriteLine("dict[{0}] = {1} , dict[{2}] = {3}, v[{4}] = {5}", iminus, dict[iminus], i, dict[i], iplus, dict[iplus]);
            });
        }

        private static void Safe()
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < 100; i++)
            {
                dic.Add(i, i);
            }
            
            var dict = new ConcurrentDictionary<int, int>(dic);
            
            Parallel.ForEach(dict, pair =>
            {
                var i = pair.Key;
                var iminus = Math.Max(i - 1, 0);
                var iplus = Math.Min(i + 1, 100);

                dict[iminus] = dict[i];
                dict[iplus] = dict[i];

                Console.WriteLine("dict[{0}] = {1} , dict[{2}] = {3}, v[{4}] = {5}", iminus, dict[iminus], i, dict[i], iplus, dict[iplus]);
            });
        }
    }
}