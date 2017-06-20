using System;
using System.Net;

namespace Lessons._05
{
    // Write thread-unsafe implementation of System.Lazy<T>.
    // Provide just public Lazy(Func<T> valueFactory) constructor.
    // Use the new class LazyThreadUnsafe<T> for googleContentLazy.
    public class TaskD
    {
        public static void Run()
        {
            Lazy<string> googleContentLazy = new Lazy<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            LazyThreadUnsafe<string> myLazy = new LazyThreadUnsafe<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            //Console.WriteLine(googleContentLazy.Value);
            Console.WriteLine(myLazy.IsValueCreated);
            Console.WriteLine(myLazy.Value.Length);
            Console.WriteLine(myLazy.IsValueCreated);
        }
    }

    public class LazyThreadUnsafe<T>
    {
        private readonly Func<T> _valueFactory;
        private bool _isValueCreated;
        private T _value;

        public LazyThreadUnsafe(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
        }

        
        public bool IsValueCreated
        {
            get
            {
                return _isValueCreated;
            }
        }


        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    _value = _valueFactory();
                    _isValueCreated = true;
                }
                return _value;
            }
        }
    }
}