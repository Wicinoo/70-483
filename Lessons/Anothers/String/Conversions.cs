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
