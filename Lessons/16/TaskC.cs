using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._16
{
    /*
    C. Implement TaskC.IsCzBankHoliday()
    Use a jagged array to hold bank holidays in 2017 in the Czech Republic. Structure the array by months.
    Data from https://www.cnb.cz/en/public/media_service/schedules/media_svatky.html
    */
    public static class TaskC
    {

        private static bool[][] _holidays = new bool[][] {
            new bool[] {true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false, false,false,false,false,false,false,false,false,false,false, false },
            new bool[] {false,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            new bool[] {false,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false, false, false }
        };

        public static void Run()
        {
            Console.WriteLine(IsCzBankHoliday(new DateTime(2017, 1, 2)));
            Console.WriteLine(IsCzBankHoliday(new DateTime(2017, 1, 1)));
        }

        /// <summary>
        /// Returns true if the date is a bank holiday in the Czech Republic.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns>True if the date is a bank holiday in the Czech Republic.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If date is not in 2017.</exception>
        public static bool IsCzBankHoliday(DateTime date)
        {
            RaiseExceptionIfNot2017Year(date);
            return _holidays[date.Month - 1][date.Day - 1];
        }

        private static void RaiseExceptionIfNot2017Year(DateTime date)
        {
            if (date.Year != 2017) throw new ArgumentOutOfRangeException("Only for 2017");
        }
    }
}
