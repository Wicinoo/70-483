using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Lessons._10
{
    public static class StaticClassWithAMethod 
    {
        public static List<string> randomStrings = Enumerable.Range(1, 1000).Select(_ => RandomString(10)).ToList();

        public static void TaskAB()
        {
            Console.WriteLine("Joining(): " + Measure(Joining).TotalMilliseconds + "ms");
            Console.WriteLine("Building(): " + Measure(Building).TotalMilliseconds + "ms");
            Console.WriteLine("Concatenation(): " + Measure(Concatenation).TotalMilliseconds + "ms");
        }

        public static void TaskE()
        {
            var date = new DateTime();

            Console.WriteLine(DateTime.Now);
        }

        public static TimeSpan Measure(Action actionToMeasure)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            actionToMeasure.Invoke();

            return stopwatch.Elapsed;
        }

        public static void Joining()
        {
            var x = string.Empty;

            for (int i = 0; i < 1000; i++)
            {
                x += randomStrings[i];
            }
        }

        public static void Building()
        {
            var x = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                x.Append(randomStrings[i]);
            }
        }

        public static void Concatenation()
        {
            var x = string.Empty;

            for (int i = 0; i < 1000; i++)
            {
                x = string.Concat(x, randomStrings[i]);
            }
        }

        private static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public static class TaskCD
    {
        public static string MapDigitsToNumbers(this string input)
        {
            return input;
            //dunno what to do here really :/
        }

        public static string RemoveLastOccurence(this string input, string occurence)
        {
            var lastIndex = input.LastIndexOf(occurence, StringComparison.CurrentCulture);

            if (lastIndex != -1)
            {
                return input.Substring(0, lastIndex);
            }

            return input;
        }

        public static string UpperToDoubleLower(this string input)
        {
            Regex regex = new Regex("([A-Z])");

            return regex.Replace(input, match =>
            {
                var lowerVersion = match.Groups[0].ToString().ToLower();

                return lowerVersion + lowerVersion;
            });
        }

        public static string IgnoreWhiteSpace(this string input)
        {
            Regex whitespace = new Regex("\\s");

            return whitespace.Replace(input, string.Empty);
        }

        public static string IterateOverString(this string input)
        {
            return input;
            //dunno what to do here really :/
        }
    }

    public static class TaskE
    {
        public static void Run()
        {
            UkEnglish();
            UsEnglish();
            Czech();
            German();
        }

        public static void UkEnglish()
        {
            var current = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-gb");
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = current;
            }
        }

        public static void UsEnglish()
        {
            var current = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
                PrintDates();
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = current;
            }
        }

        public static void Czech()
        {
            var current = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("cs-CZ");
                PrintDates();
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = current;
            }
        }

        public static void German()
        {
            var current = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-DE");
                PrintDates();
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = current;
            }
        }

        private static void PrintDates()
        {
            DateTime dt = DateTime.Now;

            Console.Write(dt.ToString("D"));
            Console.Write(dt.ToString("F"));
            Console.Write(dt.ToString("O"));
            Console.Write(dt.ToString("Y"));
        }
    }

    public static class TaskG
    {
        public static void Run()
        {
            IsValidName("Kent Beck"); // true
            IsValidName("Kent"); // true
            IsValidName("Kent Beck Jr"); // true
            IsValidName("KentBeck"); // false
            IsValidName("Kent  Beck"); // false (two spaces)
            IsValidName("Kent Beck Beck Beck"); // false (too many words)
            IsValidName("Kent BECK"); // false (upper chars on other positions in the word)
        }

        public static void IsValidName(string input)
        {
            var validName = "[A-Z][a-z]+";

            Regex regex = new Regex($"^({validName}[ ]){{0,2}}{validName}$");

            Console.WriteLine(regex.IsMatch(input));
        }
    }
}