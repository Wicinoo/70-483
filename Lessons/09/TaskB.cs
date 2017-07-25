//#define MySymbol

using System;

namespace Lessons._09
{
    /// <summary>
    /// Use compiler directives to:
    /// - define a symbol MySymbol just for Debug configuration.
    /// - if MySymbol is defined, print "MySymbol is defined" within Run() method.
    /// - put a warning "This code is obsolete" somewhere.
    /// - trigger an error in Debug configuration at some point of code.
    /// - disable warnings for a part of code for non-Debug configuration.
    /// - try to run the task in Debug and Release configuration.
    /// </summary>
    class TaskB
    {
        public static void Run()
        {
#if MySymbol
            System.Console.WriteLine("MySymbol is defined");
#endif

#if DEBUG
            System.Console.WriteLine("in debug");
#endif

#if !DEBUG
            System.Console.WriteLine("in release");
#endif



#if !DEBUG
#pragma warning disable
#endif
            //disabled warnings
#if !DEBUG
#pragma warning restore
#endif
        }

#warning This code is obsolete
        private static void ObsoleteMethod()
        {
        }
    }
}
