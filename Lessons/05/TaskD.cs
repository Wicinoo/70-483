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

            LazyThreadUnsafe<string> googleOwnContentLazy = new LazyThreadUnsafe<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            Console.WriteLine(googleOwnContentLazy.Value);
        }
    }

    public class LazyThreadUnsafe<T> where T : class
    {
        private Func<T> valueFactory;

        public LazyThreadUnsafe(Func<T> valueFactory)
        {
            this.valueFactory = valueFactory;
        }

        public T Value => valueFactory.Invoke();
    }
}