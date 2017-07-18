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
            //instantiate
            var constructor = typeof (MyGuidHolder).GetConstructor(Type.EmptyTypes);

            if (constructor != null)
            {
                var instance = constructor.Invoke(new object[] {});

                BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
                FieldInfo field = typeof(MyGuidHolder).GetField("guid", bindFlags);
                Console.WriteLine(field.GetValue(instance));
            }

        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}