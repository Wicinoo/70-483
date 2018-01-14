using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._16
{
    /*
     * Implement UniqueList<T> as a custom collection that behaves exactly as List<T> but does not allow inserting duplicate items.
     * The collection must throw exceptions as per its doucmentation comment.
     * Make sure you test your solution for all methods that can insert items (Add, AddRange, Insert, InsertRange).
     * Hint: You can inherit from List<T> to save a lot of work.
     */
    public static class TaskA
    {
        public static void Run()
        {
            PerformExampleOperations(new List<int>());
        }

        public static void PerformExampleOperations(List<int> collection)
        {
            collection.Add(1);
            collection.Add(1);
            collection.AddRange(new int[] { 1, 2 });
            collection.AddRange(new int[] { 1, 2 });
            collection.Insert(0, 1);
            collection.InsertRange(0, new int[] { 1, 2 });
        }
    }

    /// <summary>
    /// Behaves exactly like List<T> except it doesn't allow inserting duplicate items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">When trying to insert item that already exists in the collection</exception>
    public class UniqueList<T>
    {
        //TODO
    }
}
