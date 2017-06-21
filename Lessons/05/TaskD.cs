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
                Console.WriteLine($"'Lazy' just called");
                return new WebClient().DownloadString("http://www.google.com").Length.ToString();
            });
            Console.WriteLine($"Lazy prepared");
            Console.WriteLine(googleContentLazy.Value);

            LazyThreadUnsafe<string> googleContetnThreadUnsafe = new LazyThreadUnsafe<string>(() =>
            {
                Console.WriteLine($"'Own Lazy' just called");
                return new WebClient().DownloadString("http://www.google.com").Length.ToString();
            });
            Console.WriteLine($"Own Lazy prepared");
            Console.WriteLine(googleContetnThreadUnsafe.Value);
        }
    }

    public class LazyThreadUnsafe<T> where T : class
    {
        private readonly Func<T> _valueFactory;

        public LazyThreadUnsafe(Func<T> valueFactory )
        {
            _valueFactory = valueFactory;
        }

        public T Value => (T)_valueFactory.Invoke();
    }
}