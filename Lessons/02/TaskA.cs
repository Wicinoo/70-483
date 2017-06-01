using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            Task task = Task.Run(() =>
            {
                foreach (var member in Thread.CurrentThread.GetType().GetMembers())
                {
                    if (member.MemberType == MemberTypes.Property)
                    {
                        var propertyValue =
                            Thread.CurrentThread.GetType().GetProperty(member.Name).GetValue(Thread.CurrentThread);

                        if (propertyValue != null)
                        {
                            Console.WriteLine(member.Name + " : " + propertyValue);
                        }
                    }
                }
            });

            task.Wait();
        }
    }
}