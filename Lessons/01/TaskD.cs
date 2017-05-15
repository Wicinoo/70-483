using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Fruit GetFruit(); //more generic

        delegate Banana GetBanana(); //more devived

        public static void Run()
        {
            // The delegate requires Fruit as a return type, the method returns Fruit.
            GetFruit getFruit = GetGenericFruit;

            // The delegate requires Fruit as a return type, the method returns Banana (more derived type)
            // This is possible because of "covariance".
            GetFruit getBananaFromKitchen = GetBananaFromKitchen;

            var fruits = new[]
            {
                getBananaFromKitchen(),
                getFruit()
            };

            Console.WriteLine($"We have these fruits: {fruits[0].GetType().Name} and {fruits[1].GetType().Name}");

            // The delegate requires Banana as a return type, 
            // the method returns Fruit (more generic type).
            // This is not possible.

            //GetBanana getBananaFromRandomFruit = GetFruit;

            // The delegate requires banana as a return type, the method returns FrontendDeveloper.
            GetBanana getBanana = GetBananaFromKitchen;

            var banana = getBanana();
            Console.WriteLine(banana.GetType().Name);
        }

        private static Fruit GetGenericFruit()
        {
            Console.WriteLine("Getting a generic fruit.");
            return new Fruit();
        }

        private static Banana GetBananaFromKitchen()
        {
            Console.WriteLine("Getting a banana from the kitchen before ops take them all ;)");
            return new Banana();
        }

        private static Orange GetOrangeFromKitchen()
        {
            Console.WriteLine("Getting an orange from the kitchen.");
            return new Orange();
        }
    }

    class Fruit { }
    class Banana : Fruit { }
    class Orange : Fruit { }
}