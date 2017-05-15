using System;

namespace Lessons._01
{
    public static class _04_Contravariance
    {
        delegate void FeedAnimal(Animal animal);
        delegate void FeedCat(Cat cat);

        public static void Run()
        {
            // Contravariance - permits use a method with less derived types in argument for a delegate.

            // delegate requires Animal and method requires Animal
            FeedAnimal feedAnimalWater = DrinkWater;
            feedAnimalWater(new Animal());
            feedAnimalWater(new Cat());

            // delegate requires Animal + method requires Cat
            // It is not possible to pass any animal if we expect only cats.
            //FeedAnimal feedAnimalMilk = DrinkMilk;      

            // delegate requires Cat and method requires Animal
            // It is possible because of Contravariance - A cat can drink water.
            FeedCat feedCatWater = DrinkWater;
            feedCatWater(new Cat());
            
            // delegate requires Cat and method requires Cat
            FeedCat feedCatMilk = DrinkMilk;
            feedCatMilk(new Cat());
        }

        private static void DrinkWater(Animal animal)
        {
            Console.WriteLine($"{animal.GetType().Name} is drinking water.");
        }
        private static void DrinkMilk(Cat cat)
        {
            Console.WriteLine($"{cat.GetType().Name} is drinking milk.");
        }
    }

    class Animal { }

    class Cat : Animal { }
}