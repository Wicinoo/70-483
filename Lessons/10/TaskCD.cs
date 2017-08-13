using System;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Lessons._10
{
    public class TaskCD
    {

        private const string validchars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public static void Run()
        {
            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary"));
            Console.WriteLine("Hello \t42".ApplyCrazyMapping());
        }
    }

    public static class TaskCExtensions
    {
        public static string RemoveLastOccurrence(this string text, string toReplace)
        {
            var lastOccurenceIndex = text.LastIndexOf(toReplace, StringComparison.InvariantCulture);

            return lastOccurenceIndex == -1 ? text : text.Remove(lastOccurenceIndex, toReplace.Length).Insert(lastOccurenceIndex, string.Empty);
        }

        public static string ApplyCrazyMapping(this string text)
        {
            return text.Select(charInText =>
            {
                var output = new StringBuilder();
                if (char.IsWhiteSpace(charInText))
                {
                    output.Append(string.Empty);
                }
                else if (char.IsUpper(charInText))
                {
                    output.Append(char.ToLower(charInText));
                    output.Append(char.ToLower(charInText));
                }
                else if (char.IsNumber(charInText))
                {
                    output.Append("#");
                }
                else
                {
                    output.Append(charInText);
                }
                return output.ToString();
            }).Aggregate((i,j) => i + j);
        }
    }
}