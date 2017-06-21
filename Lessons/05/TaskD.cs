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

            var i = Factory.Instance;
            i.someNumber = 10;
            var j = Factory.Instance;
            j.someNumber = 25;

            var k = LazyThreadUnsafe.Instance;
            
            Console.WriteLine(i.method());
            Console.WriteLine(j.method());
            Console.WriteLine(k.googleContentLazy.Value);
            
        }

    }

    public sealed class Factory
    {
        private static readonly Lazy<Factory> lazy =
            new Lazy<Factory>(() => new Factory());

        public static Factory Instance { get { return lazy.Value; } }

        public int someNumber { get; set; }

        public string method()
        {
            return string.Format("This method does something and returns {0}", someNumber);
        }

        private Factory()
        {
        }
    }

    public class LazyThreadUnsafe
    {
        private static LazyThreadUnsafe instance = null;

        private LazyThreadUnsafe()
        {
        }

        public static LazyThreadUnsafe Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LazyThreadUnsafe();
                }
                return instance;
            }
        }


        public Lazy<string> googleContentLazy = new Lazy<string>(() =>
          {
              return new WebClient().DownloadString("http://www.google.com");
          });


    }
}