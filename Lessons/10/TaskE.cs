using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace Lessons._10
{
    public class TaskE
    {
        private static string[] cultures = { "en-GB", "en-US", "cs-CZ", "zh-SG", "sk-SK" };
        private static string[] formats = { "D", "F", "o", "Y"};
        public static void Run()
        {
            formats.ForEach(f => cultures.ForEach(c => Console.WriteLine(DateTime.Now.ToString(f,new CultureInfo(c)))));
        }
    }
}
