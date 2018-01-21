using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.String
{
    public class StringFormat
    {
        public static void Run()
        {
            DateTime time = DateTime.Now;
            //sometime we have one symbol which can by used in two way, for example
            // d - day <1-31>
            // d - standard date format, depencs on culture
            // if we want to use d we have to use prefix symbol %

            //compare
            PrintDateTimeInFormat("{0:%d}", time);
            PrintDateTimeInFormat("{0:d}", time);
            PrintDateTimeInFormat("sortable format {0:s}", time);
            Console.Write("DateTimeFormatInfo.InvariantInfo");
            Console.WriteLine(time.ToString("d", DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine(time.ToString("t", DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine(time.ToString("s", DateTimeFormatInfo.InvariantInfo));  //sortable format

            //standard date format can be different for different culture
            PrintDateWithSpecificCulture("d", "en-US", time);
            PrintDateWithSpecificCulture("d", "en-UK", time);
            PrintDateWithSpecificCulture("d", "cs-CZ", time);
            PrintDateWithSpecificCulture("d", "cz-CZ", time);

            PrintDateWithSpecificCulture("t", "en-US", time);
            PrintDateWithSpecificCulture("t", "en-UK", time);
            PrintDateWithSpecificCulture("t", "cs-CZ", time);

            PrintDateTimeInFormat("{0:t}", time);


            PrintDateTimeInFormat("{0:hh:mm}", time);

            PrintDateTimeInFormat("Is wrong, because mm is minutes {0:dd/mm/yy}", time);
            PrintDateTimeInFormat("{0:dd/MM/yy}", time);
            PrintDateTimeInFormat("{0:MM/dd/yy}", time);
            PrintDateTimeInFormat("{0:MM/dd/yyyy}", time);

            PrintDateTimeInFormat("0:h throw exception!! you have to use {0:%h}", time);

            Console.WriteLine("Example for other value types");
            Console.WriteLine("Decimal nubmer = 0.5m;");
            decimal number = 0.5m;
            Console.WriteLine("p InvariantInfo " + number.ToString("p", DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine("N InvariantInfo " + number.ToString("N", DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine("C InvariantInfo " + number.ToString("C", DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine("C en-Us " + number.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

        }

        private static void PrintDateWithSpecificCulture(string v1, string v2, DateTime time)
        {
            Console.Write($"Template: {v1} ");
            Console.Write($"Culture: {v2} ->");
            Console.Write(time.ToString(v1, CultureInfo.CreateSpecificCulture(v2)));
            Console.WriteLine();
        }


        /*
         * d and invariant culture = 01/18/2018
         * t and invariant culture =  22:57
         * t and PM/AM format 10:57 PM - you can use en-UK or en-US
         * s - sortable format
         * 
         * d    day <1-31>
         * dd   day <01-31>
         * ddd  shortcut for day of week
         * dddd full name of day in week
         * 
         * h    hour <1-12>
         * hh   hour <01-12>
         * H    hour in 24format  <0-23>
         * HH   hour in 24format <01-23>
         * 
         * m    minutes <0-59>
         * m    minutes <00-59>
         *
         * M    month   <1-12>
         * MM   month   <01-12>
         * 
         * 
         * N3   specific decimal places for numbers (in this cases  xx.xxx
         * N0   0
         * N1   0.0
         * 
         * P    percent   0.00 %
         * P0   0 %
         * P1   0.0 %
         * 
         * 
         * C    money  $1,053.32
         * C0   $1,054
         * 
         */
        private static void PrintDateTimeInFormat(string template, DateTime time)
        {
            Console.Write(template + "-> ");
            Console.Write(string.Format(template, time));
            Console.WriteLine();
        }
    }
}
