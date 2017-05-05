using System;

namespace Lessons._01
{
    public static class _05_Covariance
    {
        delegate Developer GetDeveloper();

        delegate FrontendDeveloper GetFrontendDeveloper();

        public static void Run()
        {
            // The delegate requires Developer as a return type, the method returns Developer.
            GetDeveloper getGraduate = GetGraduate;

            // The delegate requires Developer as a return type, the method returns FrontendDeveloper (more derived type)
            // This is possible because of "covariance".
            GetDeveloper getFrontendDeveloperFromBodyShop = GetFrontendDeveloperFromBodyShop;

            var developers = new[]
            {
                getFrontendDeveloperFromBodyShop(),
                getGraduate()
            };

            Console.WriteLine($"We have these developers: {developers[0].GetType().Name} and {developers[1].GetType().Name}");

            // The delegate requires FrontendDeveloper as a return type, 
            // the method returns Developer (more generic type).
            // This is not possible.

            //GetFrontendDeveloper getFrontendDeveloperFromGraduate = GetGraduate;

            // The delegate requires FrontendDeveloper as a return type, the method returns FrontendDeveloper.
            GetFrontendDeveloper getFrontendDeveloper = GetFrontendDeveloperFromBodyShop;

            var frontendDeveloper = getFrontendDeveloper();
        }

        private static Developer GetGraduate()
        {
            Console.WriteLine("Getting a graduate developer.");
            return new Developer();
        }

        private static FrontendDeveloper GetFrontendDeveloperFromBodyShop()
        {
            Console.WriteLine("Getting a front-end developer from the body shop.");
            return new FrontendDeveloper();
        }

        private static BackendDeveloper GetBackendDeveloperFromBodyShop()
        {
            Console.WriteLine("Getting a back-end developer from the body shop.");
            return new BackendDeveloper();
        }
    }

    class Developer { }
    class FrontendDeveloper : Developer { }
    class BackendDeveloper : Developer { }

}