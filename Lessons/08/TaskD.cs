using System;
using System.Linq;
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
            var instance = Activator.CreateInstance(typeof(MyGuidHolder));
            Console.WriteLine(instance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(f => f.FieldType == typeof(Guid)).GetValue(instance));
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}