using System;

namespace Lessons._01
{
    public static class _07_SystemDelegates
    {
        public static void Run()
        {
            Action emptyAction = () => { };

            Action<string> actionForString = @string => Console.WriteLine(@string);

            Action<int, int> actionForTwoNumbers = (a, b) =>
            {
                var c = a + b;
                Console.WriteLine(c);
            };

            Func<int> random10 = () => new Random().Next(10);
            Func<int, int> square = number => number * number;
            Func<int, bool> isEven = number => number % 2 == 0;
            Func<int, int, int> min = (a, b) => Math.Min(a, b);
            Func<int, int, int> minWithMethodGroup = Math.Min;
            Func<string, string, bool> equalsIgnoreCase = (s1, s2) => string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);

            Predicate<int> isOdd = number => number % 2 == 1;

            Action<Action<DateTime>> invokeActionForCurrentDate = actionForDateTime => actionForDateTime(DateTime.Now);

            invokeActionForCurrentDate(dateTime => { Console.WriteLine(dateTime); });
            invokeActionForCurrentDate(dateTime => { Console.WriteLine($"Current day of week: {dateTime.DayOfWeek}"); });
        }
    }
}