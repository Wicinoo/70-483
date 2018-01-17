using System;
using System.Collections.Generic;
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
            
            PrintDateTimeInFormat("{0:t}", time);
            PrintDateTimeInFormat("{0:hh:mm}", time);
            PrintDateTimeInFormat("{0:d}", time);
            PrintDateTimeInFormat("{0:dd/mm/yy}", time);
            PrintDateTimeInFormat("{0:mm/dd/yy}", time);

        }

        private static void PrintDateTimeInFormat(string template, DateTime time)
        {
            Console.Write(template + " :");
            Console.Write(string.Format(template, time));
            Console.WriteLine();
        }
    }
}
