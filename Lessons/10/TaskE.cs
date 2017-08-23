using System;
using System.Globalization;

namespace Lessons._10
{
    public class TaskE
    {
        public static void Run()
        {
            var now = DateTime.Now;
            PrintDates(now, new CultureInfo("en-GB"));
            PrintDates(now, new CultureInfo("en-US"));
            PrintDates(now, new CultureInfo("cs-CZ"));
            PrintDates(now, new CultureInfo("zh-SG"));
        }

        private static void PrintDates(DateTime dateTime, CultureInfo cultureInfo)
        {
            Console.WriteLine(cultureInfo.DisplayName);
            Console.WriteLine("long: {0}", dateTime.ToString("f", cultureInfo));
            Console.WriteLine("full: {0}", dateTime.ToString("f", cultureInfo));
            Console.WriteLine("8601: {0}", dateTime.ToString("o", cultureInfo));
            Console.WriteLine("Y M : {0}", dateTime.ToString("Y", cultureInfo));
            Console.WriteLine();
        }
    }
}