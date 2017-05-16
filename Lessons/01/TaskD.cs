using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate FnzDeveloper FnzDeveloperDelegate();
        delegate GetHoldingsDeveloper GetHoldingsDeveloperDelegate();

        public static void Run()
        {
            FnzDeveloperDelegate fnzDevDel = GetGoodDeveloper;

            fnzDevDel = GetHeWhoShallBeKilled;

            GetHoldingsDeveloperDelegate getHoldDel;
            // we cannot assign good developer to getHoldings developer. Simply because he would most likely kill himself if he had to extend it
            //getHoldDel = GetGoodDeveloper;

            //we can assign bad developer since he is the one to blame for all of it
            getHoldDel = GetHeWhoShallBeKilled;
        }

        static FnzDeveloper GetGoodDeveloper()
        {
            return new FnzDeveloper();
        }

        static GetHoldingsDeveloper GetHeWhoShallBeKilled()
        {
            return new GetHoldingsDeveloper();
        }

    }

    class FnzDeveloper { }
    
    class GetHoldingsDeveloper: FnzDeveloper { }
}