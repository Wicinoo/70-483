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
            var myGuidHolder = Activator.CreateInstance(typeof(MyGuidHolder));
            var guid = myGuidHolder.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First().GetValue(myGuidHolder);
            Console.WriteLine(guid);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}