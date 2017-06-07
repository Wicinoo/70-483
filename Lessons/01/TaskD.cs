using System;

namespace Lessons._01
{
    delegate Fruit GetFruit();

    delegate Apple GetApple();

    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            GetFruit getFruit = GetSomeFruit;

            GetFruit getSomeFruitFromStore = GetAppleFromStore;

            GetFruit getOtherFruitFromStore = GetOrangeFromStore;

            var fruits = new[]
            {
                getFruit(),
                getSomeFruitFromStore(),
                getOtherFruitFromStore()
            };

            Console.WriteLine($"We have: {fruits[0].GetType().Name}, {fruits[1].GetType().Name} and {fruits[2].GetType().Name}");

            GetApple getApple = GetAppleFromStore;

            var apple = getApple();
            Console.WriteLine($"We have only: {apple.GetType().Name}");
        }

        private static Fruit GetSomeFruit()
        {
            Console.WriteLine("Getting some fruit.");
            return new Fruit();
        }

        private static Apple GetAppleFromStore()
        {
            Console.WriteLine("Getting an apple from store");
            return new Apple();
        }

        private static Orange GetOrangeFromStore()
        {
            Console.WriteLine("Getting an orange from store");
            return new Orange();
        }
    }

    class Fruit{ }

    class Apple : Fruit { }

    class Orange : Fruit { }
}