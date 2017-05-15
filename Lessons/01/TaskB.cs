using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public delegate string MapString(string @string);

        public static void Run()
        {
            MapString map = delegate (string x) { return x; };
            MapString map1 =         (string x) => { return x; };
            MapString map2 =                (x) => { return x; };
            MapString map3 =                  x => { return x; };
            MapString map4 =                  x => x;

            Console.WriteLine("Map string {0}", map("Map"));
            Console.WriteLine("Map1 string {0}", map1("Map"));
            Console.WriteLine("Map2 string {0}", map2("Map"));
            Console.WriteLine($"Map3 string {map3("Map")}");
            Console.WriteLine($"Map4 string {map4("Map")}");
        }
    }
}