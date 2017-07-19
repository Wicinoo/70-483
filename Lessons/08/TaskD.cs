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
            var mgh = new MyGuidHolder();
            var field = typeof(MyGuidHolder).GetField("guid", BindingFlags.NonPublic | BindingFlags.Instance); //typeof (MyGuidHolder).GetProperty("guid", BindingFlags.NonPublic);

            //var getter = prop.GetGetMethod();

            Console.WriteLine(field.GetValue(mgh));

        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}