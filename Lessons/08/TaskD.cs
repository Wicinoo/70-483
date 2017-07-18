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

            var fieldInfo = instance.GetType().GetField("guid", BindingFlags.NonPublic | BindingFlags.Instance);
            var value = fieldInfo.GetValue(instance);

            Console.WriteLine(value);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}