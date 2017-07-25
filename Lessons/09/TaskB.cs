#define MySymbol
#if DEBUG
    #pragma warning disable 
#endif
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
    /// 
    class TaskB
    {
        public static void Run()
        {
            #if MySymbol
                Console.WriteLine("MySymbol is defined");
            #endif
            
            #warning This code is obsolete
            #error Debug mode selected
        }
    }
}
