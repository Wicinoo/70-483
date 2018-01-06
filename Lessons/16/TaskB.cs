using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._16
{
    /*
     * Class MyList<T> needs a few changes in order to run code in "Run()" method. Make the necessary modifications, then uncomment the code and run it.
     */
    public class TaskB
    {
        public static void Run()
        {
            var myList = new MyList<int>() { 1, 2 };

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class MyList<T> : IEnumerable<T>
    {
        readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }
    }
}
