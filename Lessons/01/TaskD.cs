using System;
using System.Linq;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Sport GetSport();

        delegate Hockey GetHockey();

        public static void Run()
        {
            GetSport getSport = GetASport;

            GetSport getWinterSport = GetWinterSport;

            var sports = new[]
            {
                getWinterSport(),
                getSport()
            };

            if (sports != null && sports.Any())
            {
                Console.WriteLine("We have those sports:");
                foreach (var sport in sports)
                {
                    Console.WriteLine(sports.GetType().Name);
                }
            }

            GetHockey getHockey = GetWinterSport;

            var hockey = GetWinterSport();
        }

        private static Sport GetASport()
        {
            Console.WriteLine("Getting a new sport.");
            return new Sport();
        }

        private static Football GetSummerSport()
        {
            Console.WriteLine("Getting a new football.");
            return new Football();
        }

        private static Hockey GetWinterSport()
        {
            Console.WriteLine("Getting a new hockey.");
            return new Hockey();
        }
    }

    class Sport { }

    class Football : Sport { }

    class Hockey : Sport { }
}