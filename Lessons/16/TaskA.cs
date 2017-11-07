using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            PerformExampleOperations(new UniqueList<int>());
        }

        public static void PerformExampleOperations(UniqueList<int> collection)
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
    public class UniqueList<T> : List<T>
    {
        public new void Add(T item)
        {
            CheckDuplicationIfExists(item);
            base.Add(item);
        }

        private void CheckDuplicationIfExists(T item)
        {
            if (base.Contains(item)) throw new InvalidOperationException("Item exists");
        }

        public new void AddRange(IEnumerable<T> items)
        {
            CheckDuplicaitonsAndThrowExceptionIfExists(items);
            base.AddRange(items);
        }

        private void CheckDuplicaitonsAndThrowExceptionIfExists(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                CheckDuplicationIfExists(item);
            }
        }

        public new void Insert(int index, T item)
        {
            CheckDuplicationIfExists(item);
            base.Insert(index, item);
        }

        public new void InsertRange(int index, IEnumerable<T> items)
        {
            CheckDuplicaitonsAndThrowExceptionIfExists(items);
            base.InsertRange(index, items);
        }
    }


    public class UniqueListTests
    {

        [Fact]
        public void UniqueList_AddItemWithDuplication_ShouldThrowException()
        {
            UniqueList<int> uniqueList = new UniqueList<int>();
            uniqueList.Add(1);
            Assert.Throws<InvalidOperationException>(() => uniqueList.Add(1));
        }

        [Fact]
        public void UniqueList_AddRangeWithDuplicaiton_ShouldThrowException()
        {
            UniqueList<int> uniqueList = new UniqueList<int>();
            uniqueList.AddRange(new int[] { 1, 2 });
            Assert.Throws<InvalidOperationException>(() => uniqueList.AddRange(new int[] { 1, 2 }));
        }

        [Fact]
        public void UniqueList_InsertItemWithDuplication_ShouldThrowWxception()
        {
            UniqueList<int> uniqueList = new UniqueList<int>() { 1 };
            Assert.Throws<InvalidOperationException>(() => uniqueList.Insert(0, 1));
        }

        [Fact]
        public void UniqueList_InsertRangeWithDuplication_ShouldThrowWxception()
        {
            UniqueList<int> uniqueList = new UniqueList<int>() { 1, 2 };
            Assert.Throws<InvalidOperationException>(() => uniqueList.InsertRange(0, new int[] { 1, 2 }));
        }
    }
}
