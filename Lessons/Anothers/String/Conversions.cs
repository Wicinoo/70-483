using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.String
{
    public class Conversions
    {
        public static void Run()
        {

            Console.WriteLine($" To: {FloatToStringConversion(float.Epsilon)}");
            Console.WriteLine($" To: {FloatToStringConversion(float.MaxValue)}");
            Console.WriteLine($" To: {FloatToStringConversion(float.MinValue)}");
            Console.WriteLine($" To: {FloatToStringConversion(11.0001F)}");

            Single originalType = 11.000001F;
            float aliasForSingle = 11.000001F;
            if (originalType == aliasForSingle) { Console.WriteLine("=="); }
            if (originalType.Equals(aliasForSingle)) { Console.WriteLine("equals"); }
            Console.WriteLine(originalType.GetType());
            Console.WriteLine(aliasForSingle.GetType());

            float infinity = 1 / 0F;
            Console.WriteLine(float.IsInfinity(infinity));
            Console.WriteLine(float.IsPositiveInfinity(infinity));
            Console.WriteLine(float.IsNegativeInfinity(infinity));
            Console.WriteLine(float.IsNaN(infinity));

            //how looks infinity?
            Console.WriteLine($" To: {FloatToStringConversion(float.NegativeInfinity)}");
            Console.WriteLine($" To: {FloatToStringConversion(float.PositiveInfinity)}");
            Console.WriteLine(float.NegativeInfinity.ToString());
            Console.WriteLine(infinity);
        }

        public static string FloatToStringConversion(float degress)
        {
            Console.Write($"From: {degress}");
            object degreesRef = degress;
            int result = (int)(float)degreesRef;
            return result.ToString();
        }
    }
}
