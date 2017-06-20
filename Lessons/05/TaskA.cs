namespace Lessons._05
{
    /// <summary>
    /// Print the ancestors of FooClass and FooStruct.
    /// Don't use "FooClass" and "FooStruct" as magic strings. 
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            // Print "The ancestor type of FooClass is ?."
            //var fooClass = new FooClass();
            //fooClass.PrintAncestor();

            // Print "The ancestor type of FooStruct is ?."

            PrintAncestor(new FooClass());
            PrintAncestor(new FooStruct());
        }

        public static void PrintAncestor(object o)
        {
            System.Console.WriteLine($"Ancestor of {o.GetType().Name} is {o.GetType().BaseType}");
        }
    }

    class FooClass
    {
        //public void PrintAncestor()
        //{
        //    System.Console.WriteLine(this.GetType().BaseType);
        //}
    }
    struct FooStruct { }
}
