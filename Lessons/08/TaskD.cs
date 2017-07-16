using System;
using System.Reflection;

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
            var myGuidHolder = new MyGuidHolder();

            var guid = typeof(MyGuidHolder).GetField("guid",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(myGuidHolder);

            Console.WriteLine(guid);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}