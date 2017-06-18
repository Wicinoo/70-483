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

            Console.WriteLine(googleContentLazy.Value);

            var googleContentUnsafe = new LazyThreadUnsafe<string>(() => 
            new WebClient().DownloadString("http://www.google.com"));

            Console.WriteLine(googleContentUnsafe.Value);
        }

        public class LazyThreadUnsafe<T>
        {
            private readonly Func<T> _valueFactory;

            public LazyThreadUnsafe(Func<T> valueFactory)
            {
                _valueFactory = valueFactory;
            }

            public T Value => _valueFactory.Invoke();
        }
    }
}