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

        private static void Print(DateTime currentDate, CultureInfo cultureInfo)
        {
            Console.WriteLine($"culture: {cultureInfo.Name} {cultureInfo.DisplayName}");
            Console.WriteLine($"LongDate: pattern={cultureInfo.DateTimeFormat.LongDatePattern} {currentDate.ToString(cultureInfo.DateTimeFormat.LongDatePattern, cultureInfo)}");
            Console.WriteLine($"FullDate: pattern={cultureInfo.DateTimeFormat.FullDateTimePattern} {currentDate.ToString(cultureInfo.DateTimeFormat.FullDateTimePattern, cultureInfo)}");
            Console.WriteLine($"ISO8601:  {currentDate.ToString("s", cultureInfo)}");     //https://stackoverflow.com/questions/114983/given-a-datetime-object-how-do-i-get-an-iso-8601-date-in-string-format
            Console.WriteLine($"Year month {currentDate.ToString("yyyy M",cultureInfo)}");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}

