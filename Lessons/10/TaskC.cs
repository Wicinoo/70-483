//C.Write a string extension method to remove last occurrence of a substring.Examples: 

//"USA with TrumpHillary".RemoveLastOccurrence("Hillary"); // "USA with Trump"

//"TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary"); // "TrumpHillaryTrumpTrump"


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class TaskC
    {
        const int Iterations = 10000;
        const string key = "Hillary";
        private static List<string> _randomStrings = Enumerable.Range(1, Iterations).Select(_ => GetRandomString(10, key)).ToList();

        private static string GetRandomString(int length, string key)
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringPrefix = new char[length];
            var stringPostfix = new char[length];
            var random = new Random();

            for (int i = 0; i < stringPrefix.Length/2; i++)
            {
                stringPrefix[i] = chars[random.Next(chars.Length)];
            }
            for (int i = 0; i < stringPrefix.Length / 2; i++)
            {
                stringPostfix[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringPrefix) + key  + new String(stringPostfix);
        }


        internal static void Run()
        {
            Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrenceByRemove("Hillary")); // "USA with Trump"
            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrenceByRemove("Hillary")); // "TrumpHillaryTrumpTrump"
        }
    }

    
    public static class StringExtensions
    {
        public static string RemoveLastOccurrenceByRemove(this string value, string removeString)
        {
            if (value.Contains(removeString))
            {
                int lastPosition = value.LastIndexOf(removeString);
                return value.Remove(lastPosition, removeString.Length);
            }
            return value;
        }
    }


}

