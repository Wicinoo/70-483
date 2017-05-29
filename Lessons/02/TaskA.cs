using System;
using System.Runtime.Serialization;
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
            Task task = Task.Run(() => PrintTaskExecutionContextInfo());
            Console.WriteLine("Task starting...");
            Console.WriteLine();

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("Task completed.");

            task.ContinueWith(currentTask => {
                Console.WriteLine("Task status: " + Enum.GetName(typeof(TaskStatus), currentTask.Status));
            });
        }

        public static void PrintTaskExecutionContextInfo()
        {
            Thread.CurrentThread.Name = "Hello, Task";

            var apartmentState = Thread.CurrentThread.GetApartmentState();
            Console.WriteLine("Thread apartment state: " + Enum.GetName(typeof(ApartmentState), apartmentState));

            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Console.WriteLine("Thread culture: " + currentCulture.Name);

            var currentUICulture = Thread.CurrentThread.CurrentUICulture;
            Console.WriteLine("Thread UI culture: " + currentUICulture.Name);

            var threadAliveOrDead = Thread.CurrentThread.IsAlive;
            Console.WriteLine("Is thread alive: " + threadAliveOrDead);

            var threadState = Thread.CurrentThread.ThreadState;
            Console.WriteLine("Thread state: " + Enum.GetName(typeof(ThreadState), threadState));

            var isBackgroundThread = Thread.CurrentThread.IsBackground;
            Console.WriteLine("Is background: " + isBackgroundThread);

            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            Console.WriteLine("Is ThreadPool thread: " + isThreadPoolThread);

            var name = Thread.CurrentThread.Name;
            Console.WriteLine("Thread name: " + name);

            var priority = Thread.CurrentThread.Priority;
            Console.WriteLine("Thread priority: " + Enum.GetName(typeof(ThreadPriority), priority));

            var managedThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Managed thread id: " + managedThreadId);
            Console.WriteLine();

            var principalIdentity = Thread.CurrentPrincipal.Identity;
            var principalName = principalIdentity.Name;
            var principalAuthenticationType = principalIdentity.AuthenticationType;

            principalName = "None";
            principalAuthenticationType = "None";

            var isPrincipalAuthenticated = principalIdentity.IsAuthenticated;
            Console.WriteLine("Principal name: " + principalName);
            Console.WriteLine("Principal authentication type: " + principalAuthenticationType);
            Console.WriteLine("Principal authenticated: " + isPrincipalAuthenticated);
            Console.WriteLine();

            var threadContextId = Thread.CurrentContext.ContextID;
            Console.WriteLine("Thread context ID: " + threadContextId);

            var threadContextProperties = Thread.CurrentContext.ContextProperties;

            Console.WriteLine("Thread context properties:");
            foreach (var property in threadContextProperties)
            {
                Console.WriteLine(property.Name);
            }
       } 
    }
}