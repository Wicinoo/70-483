using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB {
        private static delegate string MapString(string @string);
        public static void Run() {
            MapString operation1 = delegate (string x) { return x; };   // Anonymous method
            MapString operation2 = (string x) => { return x; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x;   // Lambda expression (implicitly typed parameter)

            string input = "I'm Mary Poppins, y'all!";
            Console.WriteLine("Result of operation1: {0}", operation1(input));

            input = "I am Groot!";
            Console.WriteLine("Result of operation2: {0}", operation2(input));

            input = " I told Gamora how when I was a kid I used to pretend David Hasselhoff was my dad. He's a singer and actor from earth, really famous guy. Yondu didn't have a talking car, but he did have a flying arrow. He didn't have a beautiful voice of an angel, but he did have the whistle of one. Both Yondu and David Hasselhoff went on kick-ass adventures and hooked up with hot women, and fought robots. I guess David Hasselhoff did kinda end up being my dad after all, only it was you, Yondu.";
            Console.WriteLine("Result of operation3: {0}", operation3(input));

            input = "Does anybody have any tape out there? I wanna put some tape over the 'Death' button!";
            Console.WriteLine("Result of operation4: {0}", operation4(input));

            input = "Maybe this man could be your David Hasselhoff. ";
            Console.WriteLine("Result of operation5: {0}", operation5(input));
}
        }
    }
}