using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Lessons._10
{
    public class TaskE
    {
        public static void Run()
        {
            var currentDate = DateTime.Today;

            var cultures = new List<CultureInfo>() { new CultureInfo("en-UK"), new CultureInfo("en-US"), new CultureInfo("cs-CZ"), new CultureInfo("zh-SG") };

            var formats = new List<string>() {"d", "D", "O", "Y"};


            foreach (var cultureInfo in cultures)
            {
                foreach (var format in formats)
                {
                    Console.WriteLine(currentDate.ToString(format,cultureInfo));
                }
            }
        }
    }
}