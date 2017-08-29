using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskE
    {
        public static void Run()
        {
            var cultures = new List<CultureInfo>();
            cultures.Add(new CultureInfo("en-UK"));
            cultures.Add(new CultureInfo("en-US"));
            cultures.Add(new CultureInfo("cs-CZ"));
            cultures.Add(new CultureInfo("zh-SG"));

            var formats = new List<string>();
            formats.Add("D"); //long date
            formats.Add("F"); //long date with long time
            formats.Add("O"); //iso 8610
            formats.Add("Y"); //year month

            DateTime now = DateTime.Now;

            cultures.ForEach(c =>
            {
                formats.ForEach(f =>
                {
                    Console.WriteLine($"{c.Name} - {f} - {now.ToString(f, c)}");
                });
            });
        }
    }
}
