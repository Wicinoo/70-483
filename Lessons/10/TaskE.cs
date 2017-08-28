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
            Console.WriteLine(currentDate.ToString(new CultureInfo("en-GB")));
            Console.WriteLine(currentDate.ToString(new CultureInfo("en-US")));
            Console.WriteLine(currentDate.ToString(new CultureInfo("en-CZ")));
            Console.WriteLine(currentDate.ToString(new CultureInfo("zh-SG")));

        }
    }
}

