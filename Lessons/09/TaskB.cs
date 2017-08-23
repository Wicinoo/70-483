using System;

#if Debug

#define MySymbol  //symbol is defined only for debug  configuration 1.

#endif


namespace Lessons._09
{
    /// <summary>
    /// Use compiler directives to:
    /// - define a symbol MySymbol just for Debug configuration.  1.
    /// - if MySymbol is defined, print "MySymbol is defined" within Run() method. 2.
    /// - put a warning "This code is obsolete" somewhere. 3.
    /// - trigger an error in Debug configuration at some point of code. 4. 
    /// - disable warnings for a part of code for non-Debug configuration. 5. 
    /// - try to run the task in Debug and Release configuration. 6.
    /// </summary>
    /// 

    class TaskB
    {
        public static void Run()
        {
#if MySymbol
            Console.WriteLine("MySymbol is defined");  //2.
#endif
            //3
#warning This code is obsolete  

#if DEBUG
            //#error This is a really big error   //4
#endif
            //5  disable warning (in this case variable i isn't used
#pragma warning disable
            int i;
            //5 enable warnings
#pragma warning restore

        }
    }
}
