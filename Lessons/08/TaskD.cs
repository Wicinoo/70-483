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
            MyGuidHolder mgh = new MyGuidHolder();

            FieldInfo val = typeof(MyGuidHolder).GetField("guid",
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            Console.WriteLine(val.GetValue(mgh));
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}