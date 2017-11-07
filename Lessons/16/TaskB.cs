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
            //throw new NotImplementedException();

            var myList = new MyList<int>() { 1, 2 };

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class MyList<T> : IEnumerator<T>, IEnumerable<T>
    {
        List<T> _items = new List<T>();

        public T Current
        {
            get
            {
                return ((IEnumerator<T>)_items).Current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return ((IEnumerator)_items).Current;
            }
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Dispose()
        {
            _items = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        public bool MoveNext()
        {
            return ((IEnumerable<T>)_items).GetEnumerator().MoveNext();
        }

        public void Reset()
        {
            ((IEnumerable<T>)_items).GetEnumerator().Reset();
        }
        public override string ToString()
        {
            return _items.GetEnumerator().Current.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
