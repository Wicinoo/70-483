using System;

namespace Lessons._04
{
    public static class _01_ManyCatchBranches
    {
        public static void Run()
        {
            try
            {
                int.Parse("NaN");
            }
            catch (FormatException)
            {
                Console.WriteLine("An FormatException was caught.");
            }
            catch (SystemException)
            {
                Console.WriteLine("An SystemException was caught.");
            }
            catch (Exception)
            {
                Console.WriteLine("An Exception was caught.");
            }
        }
    }
}