using System;
using System.Collections;
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
            HowWorksMethodCompareToForSort();
            FormatCoins("SuperMan", 999);
            FormatCoins("SuperMan", 0);
            FormatCoins("SuperMan", 1);

            EasyConversins();



            UseArrayListImplicitCOnversionForItem();  //no

            WhatReturnsWhereMethodIsNeccesaryUseSelect(); //no it return IEnumerable

            List<Product> products = new List<Product>()
            {
                new Product() {Name ="Strawberrry", CategoryId = 1},
                new Product() {Name="Banana", CategoryId = 1}
            };
            List<Product> B_Products = (List<Product>)
                (
                from product in products
                where (product.Name.StartsWith("B"))
                select product
                );


        }

        private static void HowWorksMethodCompareToForSort()
        {
            int a = 10;
            Console.WriteLine(a.CompareTo(10));
            Console.WriteLine(a.CompareTo(11));
            Console.WriteLine(a.CompareTo(9));
        }

        private static void FormatCoins(string name, int coins)
        {
            Console.WriteLine(string.Format("Playrs {0}, collected {1} coins", name, coins.ToString("###0")));
            Console.WriteLine(string.Format("Playrs {0}, collected {1:000#} coins", name, coins));
            Console.WriteLine(string.Format("Playrs {0}, collected {1:D3} coins", name, coins));

        }
        //https://msdn.microsoft.com/cs-cz/library/microsoft.visualbasic.strings.format(v=vs.110).aspx
        //we can specify format for number x>0, x=0, x<0 - formats are separated by ;
        //Format                Number 5    Number -5   Number 0,5
        //Without format        5           -5          0.5
        //0                     5           -5          1
        //0.00                  5.00        -5,00       0.50
        //#,##0                 5           -5          1
        //$#,##0;($#,##0)       $5          ($5)        $1
        //#,##0.00;($#,##0.00)  $5.00       ($5.00)     $0.50
        //0%                    500%        -500%       50%
        //0.00%                 500.00%     -500.00%    50.00%



        private class Product
        {
            public string Name { get; set; }
            public int CategoryId { get; set; }
        }

        private static void WhatReturnsWhereMethodIsNeccesaryUseSelect()
        {
            List<int> list = new List<int>()
            {
                100,95,80,75,95
            };
            var resutl = list.Where(i => i > 80);
        }

        private static void UseArrayListImplicitCOnversionForItem()
        {
            ArrayList array1 = new ArrayList();
            int var1 = 10;
            int var2;
            array1.Add(var1);
            //var2 = array1[0];  //you cannot convert object to int implictily
            var2 = Convert.ToInt32(array1[0]);
        }

        private static void EasyConversins()
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
