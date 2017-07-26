using System;

namespace Lessons._08
{
    /// <summary>
    /// Create an instance of MyGuidHolder. 
    /// Print out the value of the guid field without touching implementation of the class.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            var holder = new MyGuidHolder();

            Console.WriteLine(holder.GetType().GUID);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}