//E.Print the current date in these cultures:
//- English - United Kingdom
//- English - United States
//- Czech - Czech Republic
//- Chinese - Singapore

//For each culture use these formats:
//- long date
//- full date long
//- ISO 8601
//- year month

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class TaskE
    {
        public static void Run()
        {
            DateTime currentDate = DateTime.Now;

            Print(currentDate, new CultureInfo("en-US"));
            Print(currentDate, new CultureInfo("en-GB"));
            Print(currentDate, new CultureInfo("en-CZ"));
            Print(currentDate, new CultureInfo("zh-SG"));
        }

        private static void Print(DateTime currentDate, CultureInfo provider)
        {
            Console.WriteLine($"culture: {provider.Name} {provider.DisplayName}");
            Console.WriteLine($"LongDate: pattern={provider.DateTimeFormat.LongDatePattern} {currentDate.ToString(provider.DateTimeFormat.LongDatePattern, provider)}");
            Console.WriteLine($"FullDate: pattern={provider.DateTimeFormat.FullDateTimePattern} {currentDate.ToString(provider.DateTimeFormat.FullDateTimePattern, provider)}");
            Console.WriteLine($"ISO8601:  {currentDate.ToString("s", provider)}");
            Console.WriteLine($"Year month {currentDate.ToString("yyyy M",provider)}");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}

