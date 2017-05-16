using System;
using System.Linq;
using System.Net;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Human GetHuman();

        delegate Woman GetWoman();

        public static void Run()
        {
            GetHuman getHuman = GetFriend;

            GetHuman getWoman = GetGirlFriend;

            var friends = new[]
            {
                getWoman(),
                getHuman()
            };

            if (friends != null && friends.Any())
            {
                Console.WriteLine("We have these friends:");
                foreach (var friend in friends)
                {
                    Console.WriteLine(friend.GetType().Name);
                }
            }

            GetWoman getGirlfriend = GetGirlFriend;

            var girlFriend = getGirlfriend();
        }

        private static Human GetFriend()
        {
            Console.WriteLine("Getting a new friend.");
            return new Human();
        }

        private static Man GetBoyFriend()
        {
            Console.WriteLine("Getting a new boyfriend.");
            return new Man();
        }

        private static Woman GetGirlFriend()
        {
            Console.WriteLine("Getting a new girlfriend.");
            return new Woman();
        }
    }

    class Human { }

    class Man : Human { }

    class Woman : Human { }
}