using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Tree GetTree();
        delegate Oak GetOak();
        
        public static void Run()
        {
            GetTree getTree = GrowTree;
            GetOak getOak = CutDownOak;

            getTree();
            getOak();

            GetTree cutDownOak = CutDownOak;
            cutDownOak();

            //GetOak growOak = GrowTree;
        }

        private static Tree GrowTree()
        {
            Console.WriteLine("You've grown a tree.");
            return new Tree();
        }

        private static Oak CutDownOak()
        {
            Console.WriteLine("You've cut down a 300 years old oak :(");
            return new Oak();
        }
    }

    public class Tree { }
    public class Oak : Tree { }
}