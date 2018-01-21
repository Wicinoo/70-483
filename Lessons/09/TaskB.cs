#if DEBUG

#define MySymbol  //symbol is defined only for debug  configuration 1.

#endif

using System;


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

#line 200 "Other"
            //debugger cannot go through this code, in exeption is row number "200"
            //v Lessons._09.TaskB.Run() v W:\Programovani\csharpRepos\NewRepo\Lessons\09\Other: řádek 200
            //v Lessons._09.Runner.Run() v W:\Programovani\csharpRepos\NewRepo\Lessons\09\Runner.cs:řádek 8
            //v Lessons.Program.Main(String[] args) v W:\Programovani\csharpRepos\NewRepo\Lessons\Program.cs:řádek 19
            //throw new Exception("ex");
#line default
            //debugger can go through this code, row number is real number
            //v Lessons._09.TaskB.Run() v W:\Programovani\csharpRepos\NewRepo\Lessons\09\TaskB.cs:řádek 39
            //v Lessons._09.Runner.Run() v W:\Programovani\csharpRepos\NewRepo\Lessons\09\Runner.cs:řádek 8
            //v Lessons.Program.Main(String[] args) v W:\Programovani\csharpRepos\NewRepo\Lessons\Program.cs:řádek 19
            //throw new Exception("ex");
#line hidden
            //the same bahavior like first example - but line numer is from real code
            //throw new Exception("ex");

#line default //line sequence have to be ended by default, or we will not able to debug next code


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
