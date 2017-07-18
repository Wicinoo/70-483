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
            MyGuidHolder holder = new MyGuidHolder();
            var fieldInfo = holder.GetType().GetField("guid",BindingFlags.NonPublic |BindingFlags.Instance);
            if (fieldInfo != null)
                Console.WriteLine(fieldInfo.GetValue(holder));
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}