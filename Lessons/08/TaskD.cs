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
            var guidInstance = new Guid();

            var privateGuid =
                typeof(MyGuidHolder).GetField("guid", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(guidInstance);//https://msdn.microsoft.com/en-us/library/4ek9c21e(v=vs.110).aspx

            Console.WriteLine(privateGuid);
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}