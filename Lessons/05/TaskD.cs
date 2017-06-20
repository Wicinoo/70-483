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

            UnsafeLazy<string> googleContentUnsafeLazy = new UnsafeLazy<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            Console.WriteLine(googleContentUnsafeLazy.Value);
        }


    }

   public class UnsafeLazy<T> : System.Lazy<T>
   {
       public UnsafeLazy(Func<T> valueFactory) : base(valueFactory,false)
       {

       }
   }
}
