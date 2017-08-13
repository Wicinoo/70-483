using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    class TaskD
    {
        public static void Run()
        {
            Console.WriteLine("Hello \t42".ApplyCrazyMapping()); // "hhello##"
        }
    }

    public static class StringExtension2
    {
        public static string ApplyCrazyMapping(this string s)
        {
            string result = s.Select((x) => { if (Char.IsDigit(x)) return '#'; else return x; }).ToString();
            result = result.Select((x) => { if (Char.IsUpper(x)) return Char.ToLower(x).ToString()+Char.ToLower(x).ToString(); else return x.ToString(); }).ToString();
            result = result.Select((x) => { if (Char.IsWhiteSpace(x)) return x.ToString(); else return ""; }).ToString();

            return result;
        }
    }
}
