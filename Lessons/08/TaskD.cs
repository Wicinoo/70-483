using System;

namespace Lessons._08
{
    using System.Reflection;

    /// <summary>
    /// Create an instance of MyGuidHolder. 
    /// Print out the value of the guid field without touching implementation of the class.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            var instance = new MyGuidHolder();

            FieldInfo fields = typeof(MyGuidHolder).GetField(
                         "guid",
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            Console.WriteLine(fields.GetValue(instance));
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}