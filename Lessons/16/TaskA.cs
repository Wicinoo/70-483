using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._16
{
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Castle.Facilities.TypedFactory.Internal;

    using Rhino.Mocks.Expectations;

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
            PerformExampleOperations(new UniqueList<int>());
        }

        public static void PerformExampleOperations(UniqueList<int> collection)
        {
            //collection.Add(1);
           // collection.Add(1);
           // collection.AddRange(new int[] { 1, 2 });
            collection.AddRange(new int[] { 1, 2 });
            collection.Insert(0, 3);
            collection.InsertRange(0, new int[] { 1, 2 });
        }
    }

    /// <summary>
    /// Behaves exactly like List<T> except it doesn't allow inserting duplicate items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="InvalidOperationException">When trying to insert item that already exists in the collection</exception>
    public class UniqueList<T> : List<T>
    {
        public new void Add(T item)
        {
            if (this.Contains(item))
            {
                throw new InvalidOperationException();
            }
            base.Add(item);
        }

        public new void AddRange(IEnumerable<T> range)
        {
            if(range.All(x => !Contains(x)))
            {
               base.AddRange(range);
               return;
            }
            throw new InvalidOperationException();
        }

        public new void Insert(int position, T item)
        {
            if (this.Contains(item))
            {
                throw new InvalidOperationException();
            }
            base.Insert(position, item);
        }

        public new void InsertRange(int position, IEnumerable<T> range)
        {
            if (range.All(x => !this.Contains(x)))
            {
                base.InsertRange(position, range);
                return;
            }
            throw new InvalidOperationException();
        }
    }
}
