using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public delegate Mammal FeedMammal(Mammal mammal);
        public static void Run()
        {
            var mammal = new Mammal();
            var whale = new Whale();

            var mammalService = new MammalService();
            FeedMammal feedMammal = mammalService.FeedMammal;

            feedMammal(whale);
            feedMammal(mammal);

            ShowHowMuchIsMammalHungry(mammal);
            ShowHowMuchIsMammalHungry(whale);
        }

        private static void ShowHowMuchIsMammalHungry(Mammal mammal)
        {
            Console.WriteLine($"{mammal.GetType().Name} is {mammal.HungryState.ToString()}");
        }

    }

    public class MammalService
    {
        public Whale FeedWhale(Whale whale)
        {
            if (whale.HungryState < HungryState.OverEate)
            {
                whale.HungryState += 1;
            }
            return whale;
        }

        public Mammal FeedMammal(Mammal mammal)
        {
            if (mammal.HungryState < HungryState.OverEate)
            {
                mammal.HungryState += 1;
            }
            return mammal;
        }
    }

    public enum HungryState
    {
        Hungry,
        NotHungry,
        OverEate

    }
    public class Mammal
    {
        public HungryState HungryState { get; set; }
    }

    public class Whale : Mammal
    {

    }

}