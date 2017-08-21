using System;
using System.Globalization;

namespace Lessons._10
{
    /*
 E. Print the current date in these cultures:
- English - United Kingdom
- English - United States
- Czech - Czech Republic
- Chinese - Singapore

For each culture use these formats:
- long date
- full date long
- ISO 8601
- year month

        https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo(v=vs.110).aspx
     */

    internal class TaskE
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
