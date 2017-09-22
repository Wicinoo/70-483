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
            var myGuidHolder = new MyGuidHolder();
            var type = myGuidHolder.GetType();
            var field = type.GetFields(BindingFlags.NonPublic |
                         BindingFlags.Instance).First(fieldInfo => fieldInfo.Name == "guid");
            Console.WriteLine($"Value of guid is {field.GetValue(myGuidHolder)}");
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}