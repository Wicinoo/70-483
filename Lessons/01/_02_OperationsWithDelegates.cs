using System;

namespace Lessons._01
{
    delegate void Logger(string message);

    public static class _02_OperationsWithDelegates
    {
        public static void Run()
        {
            var loggerCreatedByNew = new Logger(LogWithAsteriskes);
            loggerCreatedByNew("Message for the logger create by new.");

            Logger loggerCreatedByJustMethodName = LogWithPipes;
            loggerCreatedByJustMethodName("Message for the logger created by just a method name.");

            Logger multipleLogger = LogWithAsteriskes;
            multipleLogger += LogWithPipes;
            multipleLogger("Message for the multiple logger.");

            Logger duplicateLogger = LogWithAsteriskes;
            duplicateLogger += LogWithAsteriskes;
            duplicateLogger("Message for the duplicated logger.");

            Logger loggerWithRemovedLogger = LogWithAsteriskes;
            loggerWithRemovedLogger += LogWithPipes;
            loggerWithRemovedLogger -= LogWithAsteriskes;
            loggerWithRemovedLogger("Message for the logger with a removed logger.");

            //Logger emptyLogger = null;
            // Uncomment if you want to see what will happen.
            //emptyLogger("Message for the empty logger.");
        }

        private static void LogWithAsteriskes(string message)
        {
            Console.WriteLine($"** {message} **");
        }

        private static void LogWithPipes(string message)
        {
            Console.WriteLine($"|| {message} ||");
        }
    }
}