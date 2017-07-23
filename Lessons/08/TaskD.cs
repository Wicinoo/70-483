using System;

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
            MyGuidHolder guildHolder = new MyGuidHolder();
            var fieldInfo = guildHolder.GetType().GetField("guid", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Console.WriteLine(fieldInfo.GetValue(guildHolder));
        }

        class MyGuidHolder
        {
            private Guid guid = Guid.NewGuid();
        }
    }
}