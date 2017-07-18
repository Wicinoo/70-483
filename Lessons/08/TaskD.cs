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

            var guidProperty = myGuidHolder.GetType().GUID;

            Console.WriteLine($"PropertyGuid: {guidProperty}");

            var guidField = (Guid)typeof(MyGuidHolder).GetField("guid", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(myGuidHolder);

            Console.WriteLine($"PropertyField: {guidField}");
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}