using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Entertainer GetEntertainer();

        delegate Clown GetClown();

        public static void Run()
        {
            GetEntertainer hireEntertainer = HireEntertainer;

            GetClown stealClownFromCircus = StealClownFromCircus;

            var entertainers = new List<Entertainer>()
            {
                stealClownFromCircus(),
                hireEntertainer()
            };

            Console.WriteLine($"We have currently hired these entertainers: {entertainers[0].GetType().Name} and {entertainers[1].GetType().Name}");

            GetClown getNonCreepyClown = StealClownFromCircus;

            var coolClown = getNonCreepyClown();
        }

        public static Entertainer HireEntertainer()
        {
            Console.WriteLine("Browsing newspaper for entertainer.");
            return new Entertainer();
        }

        public static Clown StealClownFromCircus()
        {
            Console.WriteLine("Kidnapping Clown");
            return new Clown();
        }

        public static Mime ListeningForAMime()
        {
            Console.WriteLine("Listening out for a mime");
            return new Mime();
        }
    }

    public class Entertainer { }
    public class Clown : Entertainer { }
    public class Mime : Entertainer { }
}