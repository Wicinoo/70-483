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
            List<string> formats = new List<string> { "D", "F", "s", "yyyy-MM" };

            DateTime dt = DateTime.Now;

            CultureInfo ci_enUK = new CultureInfo("en-GB");
            CultureInfo ci_enUS = new CultureInfo("en-US");
            CultureInfo ci_CZ = new CultureInfo("cs-CZ");
            CultureInfo ci_CH = new CultureInfo("zh-SG");

            formats.ForEach(x =>
            {
                Console.WriteLine(dt.ToString(x, ci_enUK));
            });

            formats.ForEach(x =>
            {
                Console.WriteLine(dt.ToString(x, ci_enUS));
            });

            formats.ForEach(x =>
            {
                Console.WriteLine(dt.ToString(x, ci_CZ));
            });

            formats.ForEach(x =>
            {
                Console.WriteLine(dt.ToString(x, ci_CH));
            });
        }
    }
}
