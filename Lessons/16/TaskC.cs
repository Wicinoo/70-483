using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._16
{
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    using Microsoft.Office.Interop.Excel;

    /*
    C. Implement TaskC.IsCzBankHoliday()
    Use a jagged array to hold bank holidays in 2017 in the Czech Republic. Structure the array by months.
    Data from https://www.cnb.cz/en/public/media_service/schedules/media_svatky.html
    */
    public static class TaskC
    {
        /// <summary>
        /// Returns true if the date is a bank holiday in the Czech Republic.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <returns>True if the date is a bank holiday in the Czech Republic.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If date is not in 2017.</exception>
        public static void Run()
        {
            TaskC.IsCzBankHoliday(DateTime.Today);
        }

        public static bool IsCzBankHoliday(DateTime date)
        {
            string page = new WebClient().DownloadString("https://www.cnb.cz/en/public/media_service/schedules/media_svatky.html");
            var matches = Regex.Matches(page, "<(?:(h3)|p)>[^<]*</(?:(h3)|p)>");
            var tag2018 = false;
            var data = new List<string>();
            foreach (var match in matches)
            {
                if (match.ToString().Contains("2018"))
                {
                    tag2018 = true;
                }
                else if (match.ToString().Contains("2017"))
                {
                    break;
                }
                else if (tag2018)
                {
                    data.Add(Regex.Replace(match.ToString(), "<.{0,1}p>", string.Empty));
                }
            }

            string[][] bankHolidays = new string[12][];
            DateTime parsedDate;
            for (int i = 0; i < 12; i++)
            {
                bankHolidays[i] = new string[31];
            }
            foreach (var item in data)
            {
                var split = item.Split('-');
                DateTime.TryParse(split[0], out parsedDate);
                bankHolidays[parsedDate.Month - 1][parsedDate.Day - 1] = split[1];
            }
            return bankHolidays[date.Month - 1].ElementAtOrDefault(date.Day - 1) != null;
        }
    }
}
