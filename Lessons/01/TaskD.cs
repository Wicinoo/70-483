using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            PickAnyGame pickGame = PlayBattlefield;
            PickAnyGame pickSecondGame = PlaySmite;
            IWantToShootSomebody pickAction = PlayBattlefield;

            Console.WriteLine("TaskD:");
            Console.WriteLine("---------------------------------------");
            pickGame();
            pickSecondGame();
            pickAction();
            Console.WriteLine("---------------------------------------");
        }

        public static Game PlaySmite()
        {
            Console.WriteLine("I want to play Smite!");
            return new Game();
        }

        public static ActionGame PlayBattlefield()
        {
            Console.WriteLine("I want to play Battlefield!");
            return new ActionGame();
        }
    }

    delegate Game PickAnyGame();

    delegate ActionGame IWantToShootSomebody();

    public class Game
    {

    }

    public class RpgGame : Game
    {

    }
    public class ActionGame : Game
    {

    }
}
