using System;
using System.Net;
using System.Threading.Tasks;

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

            LazyThreadUnsafe<string> googleContentLazyThreadUnsafe = new LazyThreadUnsafe<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            Parallel.For(1, 10, (i) =>
            {
                Console.WriteLine(googleContentLazyThreadUnsafe.Value);
            });
        }
    }

    public class LazyThreadUnsafe<T>
    {
        public Func<T> Value; 

        public LazyThreadUnsafe(Func<T> valueFactory)
        {
            Value = valueFactory;
        }
    }
}