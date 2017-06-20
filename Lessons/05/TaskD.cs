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
            //Lazy<string> googleContentLazy = new Lazy<string>(() =>
            //{
            //    return new WebClient().DownloadString("http://www.google.com");
            //});

            Lazy<string> googleContentLazy = new LazyThreadUnsafe<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            Console.WriteLine(googleContentLazy.Value);
        }
    }

    public class LazyThreadUnsafe<T> : Lazy<T>
    {
        /*
         * /// <summary>
         * /// Initializes a new instance of the <see cref="T:System.Lazy`1"/> class. When lazy initialization occurs, the specified initialization function and initialization mode are used.
         * /// </summary>
         * /// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param><param name="isThreadSafe">true to make this instance usable concurrently by multiple threads; false to make this instance usable by only one thread at a time.</param><exception cref="T:System.ArgumentNullException"><paramref name="valueFactory"/> is null. </exception>
         * [__DynamicallyInvokable]
         * public Lazy(Func<T> valueFactory, bool isThreadSafe)
         * : this(valueFactory, isThreadSafe ? LazyThreadSafetyMode.ExecutionAndPublication : LazyThreadSafetyMode.None)
         * {
         * }
         */

        public LazyThreadUnsafe(Func<T> valueFactory) 
            : base(valueFactory, false)
        {
        }
    }
}