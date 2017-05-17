using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public delegate Human GetHuman();

        public delegate Woman GetWoman();

        public static void Run()
        {
            GetHuman getHuman = GetNewHuman;
            getHuman();

            GetHuman getHwoman = GetNewWoman;
            getHwoman();

            GetWoman getWoman = GetNewWoman;
            getWoman();

            ////GetWoman getWhuman = GetNewHuman(); cant do, cuz human can be also a man, which is in no way a woman
        }

        public static Human GetNewHuman()
        {
            Console.WriteLine("Getting a human");
            return new Human();
        }

        public static Man GetNewMan()
        {
            Console.WriteLine("Getting a man");
            return new Man();
        }

        public static Woman GetNewWoman()
        {
            Console.WriteLine("Getting a woman");
            return new Woman();
        }
    }

    public class Human
    {
    }

    public class Man : Human
    {
    }

    public class Woman : Human
    {
    }
}