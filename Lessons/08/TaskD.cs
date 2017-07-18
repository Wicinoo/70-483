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
            var guidHolder = new MyGuidHolder();
            var valueOfPrivateField =
                (Guid)typeof(MyGuidHolder)
                    .GetField("guid", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(guidHolder);
            Console.WriteLine(valueOfPrivateField);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}