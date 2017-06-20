using System;
using System.Net;

namespace Lessons._05
{
    // Write thread-unsafe implementation of System.Lazy<T>.
    // Provide just public Lazy(Func<T> valueFactory) constructor.
    // Use the new class LazyThreadUnsafe<T> for googleContentLazy.
    public class TaskD
    {
        public static void Run() {
            var googleContentLazy = new LazyThread<string>(() => new WebClient().DownloadString("http://www.google.fi"));

            Console.WriteLine(googleContentLazy.Value);
        }

		public class LazyThread<T> : System.Lazy<T> {
			public LazyThread(Func<T> valueFactory): base(valueFactory, false) {}
		}
    }
}