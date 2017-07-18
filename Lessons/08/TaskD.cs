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
            var instance = new MyGuidHolder();

            Console.WriteLine($"{instance.GetType().GetField("guid", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(instance)}");
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}