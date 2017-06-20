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
            Lazy<string> googleContentLazy = new Lazy<string>(() => new WebClient().DownloadString("http://www.google.com"));

            Console.WriteLine(googleContentLazy.Value);

            var superLazy = new LazyThreadUnsafe<string>(() => new WebClient().DownloadString("http://www.google.com"));

            Console.WriteLine(superLazy.Value);
        }
    }

    public class LazyThreadUnsafe<T>
    {
        public T Value => _valueFactory.Invoke();

        private readonly Func<T> _valueFactory;

        public LazyThreadUnsafe(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
        }
    }
}